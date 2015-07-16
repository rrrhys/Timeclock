using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataLayer;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media.Imaging;

namespace Timeclock_Client
{
    public partial class MainWindow : DevExpress.XtraEditors.XtraForm
    {

        Guid? user_token = null;

        List<job_numbers> cached_job_numbers = null;
        List<work_types> cached_work_types = null;

        Guid? currentEntryToken;
        // DataLayer.entry currentEntry = null;

        TimeclockDataInterface db = new DataLayer.WebApiDataLayer();

        public MainWindow()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            loadProcedure();
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
            if (token == null)
            {

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
                this.Enabled = false;
            }


            // get and cache job numbers.

            var job_numbers = refresh_cached_job_numbers();
            cJobNumber.Properties.Items.Clear();

            if (job_numbers != null)
            {
                foreach (var j in job_numbers)
                {
                    cJobNumber.Properties.Items.Add(j);
                }
            }

            // get and cache work types.
            var work_types = refresh_cached_work_types();
            cWorkTypes.Properties.Items.Clear();

            if (work_types != null)
            {
                foreach (var w in work_types)
                {
                    cWorkTypes.Properties.Items.Add(w);
                }
            }


            lRecordingEntries.Text = "Recording entries.";


            ContextMenu pMenu = new ContextMenu();
            MenuItem SignoutMenuItem = new MenuItem();
            MenuItem item2 = new MenuItem();

            //I have about 10 items
            //...
            SignoutMenuItem.Text = "Sign Out";
            SignoutMenuItem.Click += SignoutMenuItem_Click;
            pMenu.MenuItems.Add(SignoutMenuItem);
            this.ContextMenu = pMenu;

        }

        private void loadProcedure()
        {
            
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
            if (token == null)
            {

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
                this.Enabled = false;
            }


            // get and cache job numbers.

            var job_numbers = refresh_cached_job_numbers();
            cJobNumber.Properties.Items.Clear();

            if (job_numbers != null)
            {
                foreach (var j in job_numbers)
                {
                    cJobNumber.Properties.Items.Add(j);
                }
            }

            // get and cache work types.
            var work_types = refresh_cached_work_types();
            cWorkTypes.Properties.Items.Clear();

            if (work_types != null)
            {
                foreach (var w in work_types)
                {
                    cWorkTypes.Properties.Items.Add(w);
                }
            }


            lRecordingEntries.Text = "Recording entries.";


            ContextMenu pMenu = new ContextMenu();
            MenuItem SignoutMenuItem = new MenuItem();
            MenuItem item2 = new MenuItem();

            //I have about 10 items
            //...
            SignoutMenuItem.Text = "Sign Out";
            SignoutMenuItem.Click += SignoutMenuItem_Click;
            pMenu.MenuItems.Add(SignoutMenuItem);
            this.ContextMenu = pMenu;
        }

        void SignoutMenuItem_Click(object sender, EventArgs e)
        {
            deleteToken();
            loadProcedure();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (currentEntryToken.HasValue)
            {
                db.UpdateEntry(currentEntryToken.Value, tComments.Text, user_token.Value);

            }
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
                        var input = reader.ReadToEnd();
                        token = new Guid(input);
                    }
                }
            }
            catch { }   // If fails - just don't use preferences.
            return token;
        }


        private job_numbers[] refresh_cached_job_numbers()
        {
            if (user_token == null)
            {
                return new job_numbers[] { };
            }
            var job_numbers = db.ListJobNumbers(user_token.Value);
            cached_job_numbers = job_numbers.ToList();
            return job_numbers;
        }
        private work_types[] refresh_cached_work_types()
        {
            if (user_token == null)
            {
                return new work_types[] { };
            }
            var work_types = db.ListWorkTypes(user_token.Value);
            cached_work_types = work_types.ToList();
            return work_types;
        }

        private void bStartJob_Click(object sender, EventArgs e)
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
                var result = MessageBox.Show("Job number " + cJobNumber.Text + " doesn't exist. Add it?", "New Job Number", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    jobnumber_match = db.CreateJobNumbers(cJobNumber.Text, user_token.Value);
                    cached_job_numbers.Add(jobnumber_match);
                }
                else
                {
                    isValid = false;
                }
            }

            var worktype_match = cached_work_types == null ? null : cached_work_types.FirstOrDefault(c => c.work_type == cWorkTypes.Text);

            if (worktype_match == null)
            {
                var result = MessageBox.Show("Work type " + cWorkTypes.Text + " doesn't exist. Add it?", "New Work type", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    worktype_match = db.CreateWorkType(cWorkTypes.Text, user_token.Value);
                    cached_work_types.Add(worktype_match);
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
            lTimeStarted.Text = "Started at " + e.time_from.ToString("HH:mm");
            bStartJob.Enabled = false;
            bFinishJob.Enabled = true;
            this.Icon = new System.Drawing.Icon("1435308138_checkmark_tick.ico");
        }

        private void stopJob()
        {
            if (currentEntryToken.HasValue)
            {
                db.UpdateEntry(currentEntryToken.Value, tComments.Text, user_token.Value);

            }

            lTimeStarted.Text = "";
            currentEntryToken = null;
            bStartJob.Enabled = true;
            bFinishJob.Enabled = false;
            this.Icon = new System.Drawing.Icon("1435308241_playstation-flat-icon-cross.ico");
        }

        private void bFinishJob_Click(object sender, EventArgs e)
        {
            stopJob();
        }
    }
}