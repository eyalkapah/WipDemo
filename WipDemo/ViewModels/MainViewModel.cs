using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Security.EnterpriseData;
using WipDemo.Enums;
using WipDemo.Models;
using WipDemo.Models.UI;

namespace WipDemo.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private WipModel _wipModel;

        public ICommand CheckProtectionStatusCommand { get; set; }
        public ICommand CheckIdentityManagedStatusCommand { get; set; }

        public WipModel Model
        {
            get => _wipModel;
            set => SetProperty(ref _wipModel, value);
        }

        private bool _isUIPolicyEnabled;

        public bool IsUIPolicyEnabled
        {
            get => _isUIPolicyEnabled;
            set => SetProperty(ref _isUIPolicyEnabled, value, () => OnApplyProcessUIPolicy(value));
        }

        private UIMessage _uiPolicyStatus;

        public UIMessage UIPolicyStatus
        {
            get => _uiPolicyStatus;
            set => SetProperty(ref _uiPolicyStatus, value);
        }

        private void OnApplyProcessUIPolicy(bool value)
        {
            if (value)
            {
                var result = ProtectionPolicyManager.TryApplyProcessUIPolicy(Model.EnterpriseId);

                if (result)
                {
                    UIPolicyStatus = new UIMessage("Copy+Paste the data to a non-enterprise app should be blocked.", MessageType.Regular);
                }
                else
                {
                    UIPolicyStatus = new UIMessage("Error: Could not apply policy", MessageType.Error);
                }
            }
            else
            {
                ProtectionPolicyManager.ClearProcessUIPolicy();

                UIPolicyStatus = new UIMessage("Copy+Paste the data to a non-enterprise app should succeed.", MessageType.Success);
            }
        }

        public MainViewModel()
        {
            Model = new WipModel("microsoft.com1");

            CheckProtectionStatusCommand = new MvxCommand(CheckProtectionStatus);
            CheckIdentityManagedStatusCommand = new MvxCommand(CheckIdentityManagedStatus);
        }

        private void ApplyProcessUIPolicy()
        {
            //if (Model.IsProcessUIPolicyEnabled)
        }

        private void CheckIdentityManagedStatus()
        {
            Model.IsEnterpriseManaged = ProtectionPolicyManager.IsIdentityManaged(Model.EnterpriseId);
        }

        private void CheckProtectionStatus()
        {
            Model.IsProtectionEnabled = ProtectionPolicyManager.IsProtectionEnabled;
        }
    }
}