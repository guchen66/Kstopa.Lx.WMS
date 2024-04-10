using Bogus;
using Kstopa.Lx.Admin.Components;
using Kstopa.Lx.SugarDb.Models;
using Kstopa.Lx.SugarDb.Models.NotMapped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kstopa.Lx.Admin.Providers
{
    public class FakerProvider
    {
        public List<T> GenerateScoreFakerData<T>() where T : class
        {
           /* Randomizer.Seed = new Random(123456);
            var userScoreData = new Faker<T>("zh_CN")
                .RuleFor(p => p.ResultId, f => f.Random.Number(1, 100))
                .RuleFor(p => p.Result, f => f.Random.Number(1, 100))
                .RuleFor(o => o.CreateTime, f => f.Date.Past(3));
            return userScoreData.Generate(100);*/

            return new List<T>();
        }

        public void GetGenerateType(EntityContext context)
        {
            UserInfo user=new UserInfo();
            var component = Activator.CreateInstance(context.EntityType) as EntityBase;
        }
    }
}
