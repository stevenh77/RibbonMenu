using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace SilverlightExampleApp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                //SimpleIoc.Default.Register<IFriendsService, Design.DesignFriendsService>();
            }
            else
            {
                //SimpleIoc.Default.Register<IFriendsService, FriendsService>();
            }

            SimpleIoc.Default.Register<ClientSearchViewModel>();
            // Ensure VM
            var clientSearchVM = SimpleIoc.Default.GetInstance<ClientSearchViewModel>();
        }

        public ClientSearchViewModel ClientSearchViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ClientSearchViewModel>();
            }
        }
        
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}