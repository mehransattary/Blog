using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SettingsMeta : BaseEntity
    {
        #region MetaTags
        //***====================================================================================***//
        [Display(Name = "keywords")]
        [MaxLength(160, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_keywords { get; set; }
        //***====================================================================================***//
        [Display(Name = "description")]
        [MaxLength(160, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_description { get; set; }
        //***====================================================================================***//
        [Display(Name = " canonical  ")]
        [MaxLength(160, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_canonical { get; set; }
        //***====================================================================================***//
        [Display(Name = " author  ")]
        [MaxLength(160, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_author { get; set; }
        //***====================================================================================***//
        [Display(Name = "og:title")]
        [MaxLength(65, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_ogtitle { get; set; }
        //***====================================================================================***//
        [Display(Name = "og:description")]
        [MaxLength(160, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_ogdescription { get; set; }
        //***====================================================================================***//
        [Display(Name = "og:image")]
        public string Settings_ogimage { get; set; }
        //***====================================================================================***//
        [Display(Name = "og:url")]
        [MaxLength(160, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_ogurl { get; set; }
        //***====================================================================================***//
        [Display(Name = "og:site_name")]
        [MaxLength(65, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_ogsite_name { get; set; }
        //***====================================================================================***//
        [Display(Name = "twitter:title")]
        [MaxLength(65, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_twitter_title { get; set; }
        //***====================================================================================***//
        [Display(Name = "twitter:description")]
        [MaxLength(160, ErrorMessage = "بیشتر از  {0} کاراکترنباشد      ")]
        public string Settings_twitter_description { get; set; }
        //***====================================================================================***//
        [Display(Name = "twitter:image")]
        public string Settings_twitter_image { get; set; }
        //***====================================================================================***//
        [Display(Name = "Search_Console")]
        public string Settings_Search_Console { get; set; }
        //***====================================================================================***//
        [Display(Name = "Google_Analytics")]
        public string Settings_Google_Analytics { get; set; }
        //***====================================================================================***//
        [Display(Name = "Service_Adver_1")]
        public string Settings_Service_Adver_1 { get; set; }
        //***====================================================================================***//
        [Display(Name = "Service_Adver_2")]
        public string Settings_Service_Adver_2 { get; set; }
        //***====================================================================================***//
        [Display(Name = "Service_Adver_3")]
        public string Settings_Service_Adver_3 { get; set; }
        //***====================================================================================***//
        [Display(Name = "Service_Adver_4")]
        public string Settings_Service_Adver_4 { get; set; }
        //***====================================================================================***//
        #endregion
    }
    public class Configuration_SettingsMeta : IEntityTypeConfiguration<SettingsMeta>
    {
        public void Configure(EntityTypeBuilder<SettingsMeta> builder)
        {
            builder.HasQueryFilter(x => !x.IsDelete);

        }
    }
}
