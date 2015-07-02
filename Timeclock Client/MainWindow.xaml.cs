using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer;
using System.Windows.Threading;
using System.IO.IsolatedStorage;
using System.IO;

namespace Timeclock_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Guid? user_token = null;

        job_numbers[] cached_job_numbers = null;
        work_types[] cached_work_types = null;

        Guid? currentEntryToken;
        // DataLayer.entry currentEntry = null;

        Data db = new DataLayer.Data();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cJobNumber_LostFocus(object sender, RoutedEventArgs e)
        {
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadProcedure();

            }

        private void loadProcedure()
        {

            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_Tick;
            t.Interval = new TimeSpan(0, 0, 30);
            t.Start();

            stopJob();


            // do we have a user token?

            var token = loadToken();

            if (token != null)
            {
                // check the token is valid that we have.

                // will null the token if it's invalid.
                if (!db.CheckTokenIsValid(token))
                {
                    token = null;
                    // delete the token, to save checking every time..
                    deleteToken();
                }
            }


            // is there a user to go with this token?
            if (token == null){

                // there's no token - force new user/login.
                NewUser u = new NewUser();
                u.ShowDialog();
                token = u.user_token;
                u.Dispose();
            }



            if (token.HasValue)
            {
                saveToken(token.Value);
                user_token = token;

            }
            else
            {
                this.IsEnabled = false;
            }


            // get and cache job numbers.

            var job_numbers = refresh_cached_job_numbers();
            cJobNumber.Items.Clear();
            foreach (var j in job_numbers)
            {
                cJobNumber.Items.Add(j);
            }

            // get and cache work types.
            var work_types = refresh_cached_work_types();
            cWorkTypes.Items.Clear();
            foreach (var w in work_types)
            {
                cWorkTypes.Items.Add(w);
            }


            lRecordingEntries.Content = "Recording entries.";


            ContextMenu pMenu = new ContextMenu();
            MenuItem SignoutMenuItem = new MenuItem();
            MenuItem item2 = new MenuItem();

            //I have about 10 items
            //...
            SignoutMenuItem.Header = "Sign Out";
            SignoutMenuItem.Click += SignoutMenuItem_Click;
            pMenu.Items.Add(SignoutMenuItem);
            this.ContextMenu = pMenu;
        }

        void SignoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            deleteToken();
            loadProcedure();
        }

        private void deleteToken()
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
            storage.DeleteFile("access_token.txt");
            user_token = null;
        }

        private void saveToken(Guid p)
        {
            try
            {
                // GetUserStoreForApplication doesn't work - can't identify.
                // application unless published by ClickOnce or Silverlight
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("access_token.txt", FileMode.Create, storage))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(p);
                }

            }
            catch (Exception) { }   // If fails - just don't use preferences
        }

        private static Guid? loadToken()
        {
            Guid? token = null;
            try
            {
                // GetUserStoreForApplication doesn't work - can't identify
                // application unless published by ClickOnce or Silverlight
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
                if (storage.FileExists("access_token.txt"))
                {

                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("access_token.txt", FileMode.Open, storage))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        token = new Guid(reader.ReadToEnd());
                    }
                }
            }
            catch { }   // If fails - just don't use preferences.
            return token;
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (currentEntryToken.HasValue)
            {
                db.UpdateEntry(currentEntryToken.Value, tComments.Text);

            }
        }


        private job_numbers[] refresh_cached_job_numbers()
        {
            if (user_token == null)
            {
                return new job_numbers[] { };
            }
            var job_numbers = db.ListJobNumbers(user_token.Value);
            cached_job_numbers = job_numbers;
            return job_numbers;
        }
        private work_types[] refresh_cached_work_types()
        {
            if (user_token == null)
            {
                return new work_types[] { };
            }
            var work_types = db.ListWorkTypes(user_token.Value);
            cached_work_types = work_types;
            return work_types;
        }

        private void bStartJob_Click(object sender, RoutedEventArgs e)
        {
            if (validateJobNumberAndWorkType())
            {
                startJob();
            }
        }

        private bool validateJobNumberAndWorkType()
        {
            bool isValid = true;
            var jobnumber_match = cached_job_numbers == null ? null : cached_job_numbers.FirstOrDefault(c => c.job_number == cJobNumber.Text);

            if (jobnumber_match == null)
            {
                var result = MessageBox.Show("Job number " + cJobNumber.Text + " doesn't exist. Add it?", "New Job Number", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    jobnumber_match = db.CreateJobNumbers(cJobNumber.Text, user_token.Value);
                    refresh_cached_job_numbers();
                }
                else
                {
                    isValid = false;
                }
            }

            var worktype_match = cached_work_types == null ? null : cached_work_types.FirstOrDefault(c => c.work_type == cWorkTypes.Text);

            if (worktype_match == null)
            {
                var result = MessageBox.Show("Work type " + cWorkTypes.Text + " doesn't exist. Add it?", "New Work type", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    worktype_match = db.CreateWorkType(cWorkTypes.Text, user_token.Value);
                    refresh_cached_work_types();
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        private void startJob()
        {

            var e = new DataLayer.entry();
            e.work_type_id = cached_work_types.FirstOrDefault(c => c.work_type == cWorkTypes.Text).id;
            e.job_number_id = cached_job_numbers.FirstOrDefault(c => c.job_number == cJobNumber.Text).id;
            e.time_from = DateTime.Now;
            e.comments = tComments.Text;
            currentEntryToken = db.CreateJobEntry(e, user_token.Value);
            lTimeStarted.Content = "Started at " + e.time_from.ToString("HH:mm");
            bStartJob.IsEnabled = false;
            bFinishJob.IsEnabled = true;
            this.Icon = new BitmapImage(new Uri("1435308138_checkmark_tick.ico", UriKind.Relative));
        }

        private void stopJob()
        {
            if (currentEntryToken.HasValue)
            {
                db.UpdateEntry(currentEntryToken.Value, tComments.Text);

            }

            lTimeStarted.Content = "";
            currentEntryToken = null;
            bStartJob.IsEnabled = true;
            bFinishJob.IsEnabled = false;
            this.Icon = new BitmapImage(new Uri("1435308241_playstation-flat-icon-cross.ico", UriKind.Relative));
        }
        private void bFinishJob_Click(object sender, RoutedEventArgs e)
        {
            stopJob();
        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
