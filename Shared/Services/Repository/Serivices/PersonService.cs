using Common;
using Data.Context;
using Data.Dto;
using Data.ViewModel;
using Entities;
using Microsoft.AspNetCore.Identity;
using Repositories;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Repository
{
    public class PersonService : Repository<Person>, IPersonService
    {
        public PersonService(AppDbContext context) : base(context)
        {
        }

        public async Task AddPersonAsync(PersonDto personDto, CancellationToken cancellationToken)
        {
            try
            {
                #region Save AvatarImage + IconImage
                string filePathAvatarImage = "/images/default.png";
                string filePathIconImage = "/images/default.png";

                //check is exist AvatarImage
                if (personDto?.AvatarImage?.Length > 0)
                {
                    filePathAvatarImage = AddImage("noname", "person", personDto?.AvatarImage, cancellationToken);
                }
                if (personDto?.IconImage?.Length > 0)
                {
                    filePathIconImage = AddImage("noname", "person", personDto?.IconImage, cancellationToken);
                }
                #endregion
                #region Save Customerpage
                var Person = new Person()
                {
                    FirstName = personDto.FirstName,
                    LastName = personDto.LastName,
                    Mobile = personDto.Mobile,
                    Tellphone = personDto.Tellphone,
                    Address = personDto.Address,
                    Description = personDto.Description,
                    ShortDescription = personDto.ShortDescription,
                    Email = personDto.Email,
                    WhatsApp = personDto.WhatsApp,
                    Telegram = personDto.Telegram,
                    Instagram = personDto.Instagram,
                    Linkdin = personDto.Linkdin,
                    Youtube = personDto.Youtube,
                    Learn = personDto.Learn,
                    AvatarImage = filePathAvatarImage,
                    IconImage = filePathIconImage,
                    UserId = personDto.UserId,

                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(Person, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdatePersonAsync(PersonDto personDto, string _AvatarImage, string _IconImage, CancellationToken cancellationToken)
        {
            try
            {
                var _person = await GetByIdAsync(cancellationToken, personDto.Id);

                #region Save AvatarImage + IconImage
                string filePathAvatarImage = "/images/default.png";
                string filePathIconImage = "/images/default.png";
                string filePathAvatarImageBefore = "/images/default.png";
                string filePathIconImageBefore = "/images/default.png";
                //check is exist AvatarImage

                if (personDto?.AvatarImage?.Length > 0)
                {
                    filePathAvatarImage = AddImage("noname", "person", personDto?.AvatarImage, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_person.AvatarImage));
                }
                if (personDto?.IconImage?.Length > 0)
                {
                    filePathIconImage = AddImage("noname", "person", personDto?.IconImage, cancellationToken);
                    MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_person.IconImage));
                }
                if (personDto?.AvatarImage == null && _AvatarImage != null)
                    filePathAvatarImageBefore = _AvatarImage;
                if (personDto?.IconImage == null && _IconImage != null)
                    filePathIconImageBefore = _AvatarImage;


                #endregion
                #region Save Customerpage

                #region Properties
                _person.FirstName = personDto.FirstName;
                _person.LastName = personDto.LastName;
                _person.Mobile = personDto.Mobile;
                _person.Tellphone = personDto.Tellphone;
                _person.Address = personDto.Address;
                _person.Description = personDto.Description;
                _person.ShortDescription = personDto.ShortDescription;
                _person.Description = personDto.Description;
                _person.Email = personDto.Email;
                _person.WhatsApp = personDto.WhatsApp;
                _person.Telegram = personDto.Telegram;
                _person.Instagram = personDto.Instagram;
                _person.Learn = personDto.Learn;
                _person.Linkdin = personDto.Linkdin;
                _person.Youtube = personDto.Youtube;
                _person.UserId = personDto.UserId;

                _person.CreateDate = _person.CreateDate;
                _person.LastUpdateDate = DateTime.Now;
                #endregion

                #region Save AvatarImage
                if (personDto.AvatarImage != null)
                    _person.AvatarImage = filePathAvatarImage;
                else if (personDto.AvatarImage == null && !string.IsNullOrEmpty(_AvatarImage))
                    _person.AvatarImage = filePathAvatarImageBefore;
                else
                    _person.AvatarImage = filePathAvatarImage;
                #endregion

                #region Save IconImage
                if (personDto.IconImage != null)
                    _person.IconImage = filePathIconImage;
                else if (personDto.IconImage == null && !string.IsNullOrEmpty(_IconImage))
                    _person.IconImage = filePathIconImageBefore;
                else
                    _person.IconImage = filePathIconImage;
                #endregion

                await UpdateAsync(_person, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Person>> ShowAllPeopleAsync(CancellationToken cancellationToken, string UserId)
        {
            
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
          new Person()
          {
              FirstName = x.FirstName,
              LastName = x.LastName,
              Mobile = x.Mobile,
              AvatarImage = x.AvatarImage,
              ShortDescription=x.ShortDescription,
              Description=x.Description,
              Address=x.Address,
              WhatsApp=x.WhatsApp,
               Id = x.Id,
              LastUpdateDate = x.LastUpdateDate,
              CreateDate = x.CreateDate

          }).ToListAsync(cancellationToken);
            return result;
        }
        public  IPagedList<Person> ShowAllPeople_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
             new Person()
             {
                 FirstName = x.FirstName,
                 LastName = x.LastName,
                 Mobile = x.Mobile,
                 AvatarImage = x.AvatarImage,
                Id=x.Id,
                LastUpdateDate=x.LastUpdateDate,
                CreateDate=x.CreateDate

             }).ToPagedList(currentPage, number_showproduct);
            return result;
        }


    }
}
