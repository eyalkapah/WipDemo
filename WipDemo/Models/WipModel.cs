using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WipDemo.Models
{
    public class WipModel : MvxNotifyPropertyChanged
    {
        // Will be true if WIP Setup Developer Assistant is On and the
        // Enterprise Protected Domain includes the Enterprise ID (e.g. microsoft.com)
        private bool _isEnterpriseManaged;

        private string _enterpriseId;

        // Will be true if WIP Setup Developer Assistant is On
        private bool _isProtectionEnabled;

        public bool IsEnterpriseManaged
        {
            get => _isEnterpriseManaged;
            set => SetProperty(ref _isEnterpriseManaged, value);
        }

        public string EnterpriseId
        {
            get => _enterpriseId;
            set => SetProperty(ref _enterpriseId, value);
        }

        public bool IsProtectionEnabled
        {
            get => _isProtectionEnabled;
            set => SetProperty(ref _isProtectionEnabled, value);
        }

        private bool _isApplyProcessUIPolicyEnabled;
        private string _v;

        public WipModel(string enterpriseId)
        {
            EnterpriseId = enterpriseId;
        }

        public bool IsProcessUIPolicyEnabled
        {
            get => _isApplyProcessUIPolicyEnabled;
            set => SetProperty(ref _isApplyProcessUIPolicyEnabled, value);
        }
    }
}