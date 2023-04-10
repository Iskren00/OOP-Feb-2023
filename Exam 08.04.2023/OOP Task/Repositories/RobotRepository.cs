using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> _robots;

        public RobotRepository()
        {
            _robots = new();
        }
        public IReadOnlyCollection<IRobot> Models()
            => _robots.AsReadOnly();
        public void AddNew(IRobot model)
            => _robots.Add(model);

        public bool RemoveByName(string robotModel)
        {
            foreach (var robot in _robots)
            {
                if (robot.Model == robotModel)
                {
                    _robots.Remove(robot);
                    return true;
                }
            }

            return false;
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            foreach (var robot in _robots)
            {
                foreach (var face in robot.InterfaceStandards)
                {
                    if (face == interfaceStandard)
                    {
                        return robot;
                    }
                }
            }

            return null;
        }
    }
}
