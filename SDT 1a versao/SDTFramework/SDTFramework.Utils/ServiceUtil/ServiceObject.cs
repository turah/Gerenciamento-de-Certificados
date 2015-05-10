using System;
using System.Timers;
using System.Configuration;
using SDTFramework.Utils.Log;

namespace SDTFramework.Utils.ServiceUtil
{
    public abstract class ServiceObject
    {
        private readonly Logger _logger;
        private Timer _timer;
        private readonly object _processamento = new object();

        protected abstract string NomeServico();

        protected abstract int Intervalo();

        protected abstract bool Habilitado();

        protected abstract void Processar();

        private void ChamarProcessamento()
        {
            if (Habilitado())
            {
                lock (_processamento)
                {
                    _logger.Debug(string.Format("{0}: The processing has been started...", NomeServico()));
                    try
                    {
                        Processar();
                        _logger.Debug(string.Format("{0}: The processing has been concluded.", NomeServico()));
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("{0}: Error when processing. Erro: '{1}'", NomeServico(), ex));
                    }
                }
            }
            else
            {
                _logger.Debug(string.Format("{0}: The process is disable. Check the config file.", NomeServico()));
            }
        }

        protected ServiceObject()
        {
            _logger = new Logger(GetType());
        }

        private void StartTimer()
        {
            int interval = Intervalo();
            _timer.Interval = interval;
            _timer.Start();
            _logger.Debug(string.Format("{0}: PROCESS_INTERVAL = '{1} minutes'...", NomeServico(), interval / (60 * 1000)));
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _timer.Stop();
            ConfigurationManager.RefreshSection("appSettings");
            ChamarProcessamento();
            StartTimer();
        }

        public void OnStart(string[] args)
        {
            _timer = new Timer();
            _logger.Debug(string.Format("Starting the Service {0}.", NomeServico()));
            _timer.Elapsed += TimerOnElapsed;

            ChamarProcessamento();
            StartTimer();
        }

        public void OnStop()
        {
            _logger.Debug(string.Format("Stoping the Service {0}.", NomeServico()));
            _timer.Stop();
            _timer.Dispose();
            _logger.Debug(string.Format("{0} has been stopped.", NomeServico()));
        }

        public void OnContinue()
        {
            _logger.Debug(string.Format("Resuming the {0}...", NomeServico()));
            _timer.Start();
            _logger.Debug(string.Format("{0} has been resumed.", NomeServico()));
        }

        public void OnPause()
        {
            _logger.Debug(string.Format("Pausing the {0}...", NomeServico()));
            _timer.Stop();
            _logger.Debug(string.Format("{0} has been paused.", NomeServico()));
        }

        public void OnShutdown()
        {
            _logger.Debug(string.Format("Turning off the {0}...", NomeServico()));
            _timer.Stop();
            _timer.Dispose();
            _logger.Debug(string.Format("{0} has been turned off.", NomeServico()));
        }
    }
}