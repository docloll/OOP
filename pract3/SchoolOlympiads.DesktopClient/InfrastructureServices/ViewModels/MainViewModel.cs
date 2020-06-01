using SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase;
using SchoolOlympiads.ApplicationServices.Ports;
using SchoolOlympiads.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SchoolOlympiads.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetOlympiadListUseCase _getOlympiadListUseCase;

        public MainViewModel(IGetOlympiadListUseCase getOlympiadListUseCase)
            => _getOlympiadListUseCase = getOlympiadListUseCase;

        private Task<bool> _loadingTask;
        private Olympiad _currentOlympiad;
        private ObservableCollection<Olympiad> _olympiads;

        public event PropertyChangedEventHandler PropertyChanged;

        public Olympiad CurrentOlympiad
        {
            get => _currentOlympiad;
            set
            {
                if (_currentOlympiad != value)
                {
                    _currentOlympiad = value;
                    OnPropertyChanged(nameof(CurrentOlympiad));
                }
            }
        }

        private async Task<bool> LoadOlympiads()
        {
            var outputPort = new OutputPort();
            bool result = await _getOlympiadListUseCase.Handle(GetOlympiadListUseCaseRequest.CreateAllOlympiadsRequest(), outputPort);
            if (result)
            {
                Olympiads = new ObservableCollection<Olympiad>(outputPort.Olympiads);
            }
            return result;
        }

        public ObservableCollection<Olympiad> Olympiads
        {
            get
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadOlympiads();
                }

                return _olympiads;
            }
            set
            {
                if (_olympiads != value)
                {
                    _olympiads = value;
                    OnPropertyChanged(nameof(Olympiads));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetOlympiadListUseCaseResponse>
        {
            public IEnumerable<Olympiad> Olympiads { get; private set; }

            public void Handle(GetOlympiadListUseCaseResponse response)
            {
                if (response.Success)
                {
                    Olympiads = new ObservableCollection<Olympiad>(response.Olympiads);
                }
            }
        }
    }
}
