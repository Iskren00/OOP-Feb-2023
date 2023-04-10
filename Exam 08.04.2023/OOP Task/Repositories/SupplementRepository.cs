using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> _supplements;

        public SupplementRepository()
        {
            _supplements = new();
        }

        public IReadOnlyCollection<ISupplement> Models()
             => _supplements.AsReadOnly();

        public void AddNew(ISupplement model)
            => _supplements.Add(model);    

        public bool RemoveByName(string typeName)
        {
            Type type;

            foreach (var supplement in _supplements)
            {
                type = supplement.GetType();

                if (type.ToString() == typeName)
                {
                    _supplements.Remove(supplement);
                    return true;
                }
            }

            return false;
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            foreach (var supplement in _supplements)
            {
                if (supplement.InterfaceStandard == interfaceStandard)
                {
                    return supplement;
                }
            }

            return null;
        }
    }
}
