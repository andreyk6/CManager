using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CertifyMe.Service.DataContracts
{
    public static class DomainToContractExtension
    {
        public static User ToUserContract(this Data.User user)
        {
            return new User(user.FirstName, user.LastName, user.Age)
            {
                Id = user.Id,
                CreationTime = user.CreationTime
            };
        }
        public static Certificate ToCertificateContract(this Data.Certificate certificate)
        {
            return new Certificate()
            {
                Id = certificate.Id,
                EventId = certificate.Event.Id,
                OwnerId = certificate.Owner.Id,
                Title = certificate.Title,
                Place = certificate.Place,
                CreationTime = certificate.CreationTime
            };
        }
        public static Company ToCompanyContract(this Data.Company compamy)
        {
            return new Company()
            {
                Id = compamy.Id,
                OwnerId = compamy.Owner.Id,
                CreationTime = compamy.CreationTime,
                Name = compamy.Name,
                Description = compamy.Description
            };
        }
        public static Event ToEventContract(this Data.Event @event)
        {
            return new Event()
            {
                Id = @event.Id,
                CompanyId = @event.Company.Id,
                CreationTime = @event.CreationTime,
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                Location = @event.Location,
                Name = @event.Name,
                Description = @event.Description
            };
        }
        public static EventComment ToEventComment(this Data.EventComment eventComment)
        {
            return new EventComment()
            {
                Id = eventComment.Id,
                EventId = eventComment.Event.Id,
                CreationTime = eventComment.CreationTime,
                CommentatorId = eventComment.Commentator.Id,
                Text = eventComment.Text
            };
        }
        public static EventComment ToEventCommentContract(this Data.EventComment comment)
        {
            return new EventComment()
            {
                Id = comment.Id,
                CommentatorId = comment.Commentator.Id,
                EventId = comment.Event.Id,
                CreationTime = comment.CreationTime,
                Text = comment.Text
            };
        }
    }
}