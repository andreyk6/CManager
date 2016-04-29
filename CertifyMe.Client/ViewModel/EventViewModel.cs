using CertifyMe.Client.EventServiceReference;
using CertifyMe.Client.UserServiceReference;
using CertifyMe.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CertifyMe.Client.ViewModel
{
    public class EventViewModel : ViewModelBase
    {
        private EventServiceClient _eventService;

        private Event _event;
        public string Name
        {
            get { return _event.Name; }
            set
            {
                if (value == _event.Name)
                    return;
                _event.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _event.Description; }
            set
            {
                if (value == _event.Description)
                    return;
                _event.Description = value;
                OnPropertyChanged("Description");
            }

        }
        public string Location
        {
            get { return _event.Location; }
            set
            {
                if (value == _event.Location)
                    return;
                _event.Location = value;
                OnPropertyChanged("Location");
            }
        }
        public DateTime StartDate
        {
            get { return _event.StartDate; }
            set
            {
                if (value == _event.StartDate)
                    return;
                _event.StartDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        public DateTime EndDate
        {
            get { return _event.EndDate; }
            set
            {
                if (value == _event.EndDate)
                    return;
                _event.EndDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private List<EventComment> _comments;

        public List<EventComment> Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                if (value == _comments)
                    return;

                _comments = value;
                OnPropertyChanged("Comments");
            }
        }

        private List<EventServiceReference.User> _participants;
        public List<EventServiceReference.User> Participants
        {
            get
            {
                return _participants;
            }
            set
            {
                if (value == _participants)
                    return;

                _participants = value;
                OnPropertyChanged("Participants");
            }
        }


        #region [Comment action]
        public ICommand Comment { get; set; }
        private string commentText;
        public string CommentText
        {
            get { return commentText; }
            set
            {
                if (commentText == value)
                    return;
                commentText = value;
                OnPropertyChanged("CommentText");
            }
        }
        private bool _commentCanExecute(object parameter)
        {
            return CommentText != "";
        }
        private void _commentExecute(object parameter)
        {
            if (_eventService.AddComment(SystemUser.Instance.Id, _event.Id, CommentText))
            {
                CommentText = "";
                Comments = _eventService.GetComments(_event.Id).ToList();
            }
        }
        #endregion

        #region [Subscribe action]
        public string SubscribeBtnText
        {
            get
            {
                return subscribeBtnText;
            }
            set
            {
                if (subscribeBtnText == value)
                    return;
                subscribeBtnText = value;
                OnPropertyChanged("SubscribeBtnText");
            }
        }
        private string subscribeBtnText;
        public ICommand Subscribe { get; set; }
        private bool _subscribeCanExecute(object parameter)
        {
            return true;
        }
        private void _subscribeExecute(object parameter)
        {
            if (SubscribeBtnText == "Subscribe")
            {
                if (_eventService.RegisterUser(SystemUser.Instance.Id, _event.Id))
                    SubscribeBtnText = "UnSubscribe";
            }
            else
            {
                if (_eventService.UnregisterUser(SystemUser.Instance.Id, _event.Id))
                    SubscribeBtnText = "Subscribe";
            }
        }
        #endregion

        public EventViewModel(Guid eventId)
        {
            _eventService = new EventServiceClient();
            _event = _eventService.GetById(eventId);

            Comments = _eventService.GetComments(eventId).ToList();
            Participants = _eventService.GetParticipants(eventId).ToList();

            Comment = new BaseCommand(_commentExecute, _commentCanExecute);
            Subscribe = new BaseCommand(_subscribeExecute, _subscribeCanExecute);

            if (Participants.Any(u => u.Id == SystemUser.Instance.Id))
            {
                SubscribeBtnText = "UnSubscribe";
            }
            else
            {
                SubscribeBtnText = "Subscribe";
            }
        }
    }
}
