using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Vital.Data.Models;
using Vital.Model;

namespace Vital.Service
{
    public class CalculateRateLTLService : Vital.Service.ICalculateRateLTLService
    {

        readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<SkidWeight> _skidWeightRepo;
        private readonly IRepository<SkidRate> _skidRateRepo;

        public CalculateRateLTLService(IUnitOfWork unitOfWork, IRepository<SkidWeight> skidWeightRepo, IRepository<SkidRate> skidRateRepo)
        {
            this._skidWeightRepo = skidWeightRepo;
            this._skidRateRepo = skidRateRepo;
            this._unitOfWork = unitOfWork;
        }

        public decimal getRateResultLTL(int consideredweight, string originCity, string originState, string originCountry, string destinationCity, string destinationState, string destinationCountry)
        {


            decimal RateResult = 0;
            var getSkidWeightId = _skidWeightRepo.Query().Filter(x => x.Low <= consideredweight && x.High >= consideredweight)
               .Get().Select(x => new SkidWeightModel()
               {

                   Id = x.Id

               }).FirstOrDefault();

            if (getSkidWeightId != null)
            {
                var getSkidRate = _skidRateRepo.Query().Filter(x => x.OriginState == originState && x.OriginCity == originCity && x.OriginCountry == originCountry && x.DestinationCity == destinationCity && x.DestinationState == destinationState && x.DestinationCountry == destinationCountry && x.SkidWeightId == getSkidWeightId.Id)
                                   .Get().Select(x => new SkidRatesModel()
                                   {

                                       Rate = x.Rate,
                                       Type = x.Type

                                   }).ToList();
                List<decimal> myList = new List<decimal>();
                foreach (var item in getSkidRate)
                {
                    if (item.Type == "rate")
                    {
                        myList.Add((item.Rate * consideredweight));
                    }
                    else
                    {
                        myList.Add((item.Rate));
                    }
                }



                if (getSkidRate != null)
                {
                    RateResult = myList.OrderByDescending(r => r).Last();

                }

                return RateResult;


            }
            else
            {

                return RateResult;

            }

        }

    }
}
