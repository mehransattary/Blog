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
    public class SettingAdvertisingService : Repository<SettingAdvertising>, ISettingAdvertisingService
    {
        public SettingAdvertisingService(AppDbContext context) : base(context)
        {
        }

        public  async Task AddSettingAdvertisingAsync(SettingAdvertisingDto SettingAdvertisingDto, CancellationToken cancellationToken)
        {
            try
            {
              
                #region Save Customerpage
                var SettingAdvertising = new SettingAdvertising()
                {
                    Settings_Advertising_Title = SettingAdvertisingDto.Settings_Advertising_Title,
                    Settings_href_Title= SettingAdvertisingDto.Settings_href_Title,
                    Settings_alt_Title = SettingAdvertisingDto. Settings_alt_Title,
                    Settings_title_Title = SettingAdvertisingDto.Settings_title_Title,
                    UserId = SettingAdvertisingDto.UserId,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now

                };
                await AddAsync(SettingAdvertising, cancellationToken);
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }   

        public async Task UpdateSettingAdvertisingAsync(SettingAdvertisingDto SettingAdvertisingDto,  CancellationToken cancellationToken)
        {
            var _SettingAdvertising = await GetByIdAsync(cancellationToken, SettingAdvertisingDto.Id);

            #region Save Customerpage

            #region Properties
            _SettingAdvertising.Settings_Advertising_Title = SettingAdvertisingDto.Settings_Advertising_Title;
            _SettingAdvertising.Settings_href_Title = SettingAdvertisingDto.Settings_href_Title;
            _SettingAdvertising.Settings_alt_Title = SettingAdvertisingDto.Settings_alt_Title;
            _SettingAdvertising.Settings_title_Title = SettingAdvertisingDto.Settings_title_Title;
            _SettingAdvertising.UserId = SettingAdvertisingDto.UserId;
            _SettingAdvertising.CreateDate = _SettingAdvertising.CreateDate;
            _SettingAdvertising.LastUpdateDate = DateTime.Now;
            #endregion

            await UpdateAsync(_SettingAdvertising, cancellationToken);
            #endregion       
        }

        public async Task<IList<SettingAdvertising>> ShowAllSettingAdvertisingAsync(CancellationToken cancellationToken, string UserId)
        {
            var result = await TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
                   new SettingAdvertising()
                   {
                       UserId = x.UserId,
                       Id = x.Id,
                       LastUpdateDate = x.LastUpdateDate,
                       CreateDate = x.CreateDate,
                       Settings_Advertising_Title=x.Settings_Advertising_Title,
                       Settings_title_Title=x.Settings_title_Title


                   }).ToListAsync(cancellationToken);
            return result;
        }

        public  IPagedList<SettingAdvertising> ShowAllSettingAdvertising_PagingAsync(CancellationToken cancellationToken, string UserId, int currentPage = 0, int number_showproduct = 10)
        {
            var result = TableNoTracking.Where(x => x.UserId == UserId).Select(x =>
               new SettingAdvertising()
               {
                   UserId = x.UserId,
                   Id = x.Id,
                   LastUpdateDate = x.LastUpdateDate,
                   CreateDate = x.CreateDate,
                   Settings_Advertising_Title = x.Settings_Advertising_Title,
                   Settings_title_Title = x.Settings_title_Title

               }).ToPagedList(currentPage, number_showproduct);
                    return result;
        }
 
    }
}
