using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.AuditTrail;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XafDisableAuditTrailAtRuntime.Module.BusinessObjects;

namespace XafDisableAuditTrailAtRuntime.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DisableAuditController : ViewController
    {
        SimpleAction EnableAudit;
        SimpleAction DisableAudit;
        public DisableAuditController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            DisableAudit = new SimpleAction(this, "Disable audit", "View");
            DisableAudit.Execute += DisableAudit_Execute;

            EnableAudit = new SimpleAction(this, "Enable audit", "View");
            EnableAudit.Execute += EnableAudit_Execute;
            

        }
        private void EnableAudit_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var Customer = this.ObjectSpace.CreateObject<Customer>();
            Customer.Name = "Javier";
            this.ObjectSpace.CommitChanges();
        }
        private void DisableAudit_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //https://supportcenter.devexpress.com/ticket/details/q568049/audittrail-how-to-switch-it-off-for-a-while-and-on-again-at-runtime#
            // Execute your business logic.

            AuditTrailService.Instance.SaveAuditTrailData += Instance_SaveAuditTrailData;
            var Customer= this.ObjectSpace.CreateObject<Customer>();
            Customer.Name = "Joche";
            this.ObjectSpace.CommitChanges();
            AuditTrailService.Instance.SaveAuditTrailData -= Instance_SaveAuditTrailData;
        }
        void Instance_SaveAuditTrailData(object sender, SaveAuditTrailDataEventArgs e)
        {
            e.Handled = true;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
