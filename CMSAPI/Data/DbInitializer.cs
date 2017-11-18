using System;
namespace CMSAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CMSContext context)
        {
             
            context.Database.EnsureCreated();

        }
    }
}
