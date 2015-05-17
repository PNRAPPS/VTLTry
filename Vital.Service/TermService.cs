using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.Data.Models;
using Vital.Model;

namespace Vital.Service
{
    public class TermService : Vital.Service.ITermService
    {
        private readonly IRepository<Term> _termRepository;

        public TermService(IRepository<Term> termRepository)
        {
            this._termRepository = termRepository;
        }

        public List<ValueText> GetDropDownListData()
        {
            var list = this._termRepository
                .Query()
                .Get()
                .OrderBy(x => x.TermName)
                .Select(x => new ValueText()
                {
                    Value = x.Id.ToString(),
                    Text = x.TermName,
                });
            return list.ToList();
        }

    }
}
