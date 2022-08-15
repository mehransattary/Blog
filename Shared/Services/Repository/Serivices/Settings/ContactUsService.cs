using Common;
using Data.Context;
using Data.Dto;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Repository
{
    public class ContactUsService : Repository<ContactUs>, IContactUsService
    {
        public ContactUsService(AppDbContext context) : base(context)
        {
        }

        public async Task AddContactUsAsync(ContactUsDto ContactUsDto, CancellationToken cancellationToken)
        {
            try
            {
                string filePathContactUs_ImageDto = "/images/default.png";

                if (ContactUsDto?.ContactUs_Image?.Length > 0)
                {
                    filePathContactUs_ImageDto = AddImage("noname", "ContactUs", ContactUsDto?.ContactUs_Image, cancellationToken);
                }
                #region Save Customerpage
                var ContactUs = new ContactUs()
                {
                    ContactUs_Text = ContactUsDto.ContactUs_Text,
                    ContactUs_Image = filePathContactUs_ImageDto,
                    UserId = ContactUsDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    //=============BaseMetaTag=====================//
                    Title_Meta = ContactUsDto.Title_Meta,
                    TitleEnglish_Meta = ContactUsDto.TitleEnglish_Meta,
                    Url_Meta = ContactUsDto.Url_Meta.ToLower().Trim().Replace(' ', '-'),
                    Desc_Meta = ContactUsDto.Desc_Meta,
                    Canonical_Meta = ContactUsDto.Canonical_Meta,
                    Keyword_Meta = ContactUsDto.Keyword_Meta,
                    Image_Meta = filePathContactUs_ImageDto,
                    //===========================================//
                };
                await AddAsync(ContactUs, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateContactUsAsync(ContactUsDto ContactUsDto, string _ContactUs_Image, CancellationToken cancellationToken)
        {
            var _ContactUs = await TableNoTracking.SingleOrDefaultAsync(x => x.Id == ContactUsDto.Id, cancellationToken);

            #region Save Image
            string filePathContactUs = "/images/default.png";
            string filePathContactUsBefore = "/images/default.png";
            if (ContactUsDto?.ContactUs_Image?.Length > 0)
            {
                filePathContactUs = AddImage("noname", "ContactUs", ContactUsDto?.ContactUs_Image, cancellationToken);
                MyImages.RemoveDuplicatePhotos(MyImages.CurrentDirectory(_ContactUs.ContactUs_Image));
            }
            if (ContactUsDto?.ContactUs_Image == null && _ContactUs_Image != null)
                filePathContactUsBefore = _ContactUs_Image;


            #endregion
            #region Save ContactUs

            #region Properties

            _ContactUs.ContactUs_Text = ContactUsDto.ContactUs_Text;
            _ContactUs.UserId = ContactUsDto.UserId;
            _ContactUs.CreateDate = _ContactUs.CreateDate;
            _ContactUs.LastUpdateDate = DateTime.Now;


            _ContactUs.Title_Meta = ContactUsDto.Title_Meta;
            _ContactUs.TitleEnglish_Meta = ContactUsDto.TitleEnglish_Meta;
            _ContactUs.Url_Meta = ContactUsDto.Url_Meta;
            _ContactUs.Desc_Meta = ContactUsDto.Desc_Meta;
            _ContactUs.Canonical_Meta = ContactUsDto.Canonical_Meta;
            _ContactUs.Keyword_Meta = ContactUsDto.Keyword_Meta;
            #endregion
            #region Save Image
            if (ContactUsDto.ContactUs_Image != null)
                _ContactUs.ContactUs_Image = filePathContactUs;
            else if (ContactUsDto.ContactUs_Image == null && !string.IsNullOrEmpty(_ContactUs_Image))
                _ContactUs.ContactUs_Image = filePathContactUsBefore;
            else
                _ContactUs.ContactUs_Image = filePathContactUs;
            //==============================================//
            if (ContactUsDto.Image_Meta != null)
                _ContactUs.Image_Meta = filePathContactUs;
            else if (ContactUsDto.Image_Meta == null && !string.IsNullOrEmpty(_ContactUs_Image))
                _ContactUs.Image_Meta = filePathContactUsBefore;
            else
                _ContactUs.Image_Meta = filePathContactUs;
            #endregion
            await UpdateAsync(_ContactUs, cancellationToken);
            #endregion       
        }

        public async Task<IList<ContactUs>> ShowAllContactUsAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
                   new ContactUs()
                   {
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,
                       ContactUs_Image = x.ContactUs_Image,
                       ContactUs_Text = x.ContactUs_Text,


                   }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<ContactUs> ShowAllContactUsAsync(CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.Select(x =>
                   new ContactUs()
                   {
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,
                       ContactUs_Image = x.ContactUs_Image,
                       ContactUs_Text = x.ContactUs_Text,


                   }).FirstOrDefaultAsync(cancellationToken);
            return result;
        }
        public ContactUs ShowAllContactUs()
        {
            var result = TableNoTracking.Select(x =>
                   new ContactUs()
                   {
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,
                       ContactUs_Image = x.ContactUs_Image,
                       ContactUs_Text = x.ContactUs_Text,


                   }).FirstOrDefault();
            return result;
        }

        public IPagedList<ContactUs> ShowAllContactUs_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {

            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
                  new ContactUs()
                  {
                      UserId = x.UserId,
                      Id = x.Id,
                      LastUpdateDate = x.LastUpdateDate,
                      CreateDate = x.CreateDate,
                      ContactUs_Image = x.ContactUs_Image,
                      ContactUs_Text = x.ContactUs_Text,


                  }).ToPagedList(currentPage, number_showproduct);

            return result;


        }

    }
}
