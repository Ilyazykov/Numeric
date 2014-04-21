using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Lab6.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestTaskViewModel>();
            SimpleIoc.Default.Register<FirstTaskViewModel>();
            SimpleIoc.Default.Register<SecondTaskViewModel>();
        }

        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public TestTaskViewModel TestTask
        {
            get { return ServiceLocator.Current.GetInstance<TestTaskViewModel>(); }
        }

        public FirstTaskViewModel FirstTask
        {
            get { return ServiceLocator.Current.GetInstance<FirstTaskViewModel>(); }
        }

        public SecondTaskViewModel SecondTask
        {
            get { return ServiceLocator.Current.GetInstance<SecondTaskViewModel>(); }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}