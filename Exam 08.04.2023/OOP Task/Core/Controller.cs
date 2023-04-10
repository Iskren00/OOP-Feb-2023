using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            supplements = new();
            robots = new();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != "DomesticAssistant" && typeName != "IndustrialAssistant")
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            if (typeName == "DomesticAssistant")
            {
                IRobot robot = new DomesticAssistant(model);

                robots.AddNew(robot);

                return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
            }
            else
            {
                IRobot robot = new IndustrialAssistant(model);

                robots.AddNew(robot);

                return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
            }
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != "SpecializedArm" && typeName != "LaserRadar")
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            if (typeName == "SpecializedArm")
            {
                ISupplement supplement = new SpecializedArm();
                supplements.AddNew(supplement);

                return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
            }
            else
            {
                ISupplement supplement = new LaserRadar();
                supplements.AddNew(supplement);

                return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
            }
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            int supplementInterfaceValue = 0;
            List<IRobot> robotsNotContainIS = new();

            foreach (var supplement in supplements.Models())
            {
                string type = supplement.GetType().ToString();

                if (type == $"RobotService.Models.{supplementTypeName}")
                {
                    supplementInterfaceValue = supplement.InterfaceStandard;
                    break;
                }
            }

            foreach (var robot in robots.Models())
            {
                if (robot.InterfaceStandards.Count == 0)
                {
                    robotsNotContainIS.Add(robot);
                }

                foreach (var IS in robot.InterfaceStandards)
                {
                    if (IS != supplementInterfaceValue)
                    {
                        robotsNotContainIS.Add(robot);
                    }
                }
            }

            List<IRobot> robotsNotContainsISCopy = new(robotsNotContainIS);

            foreach (var robot in robotsNotContainIS)
            {
                if (robot.Model != model)
                {
                    robotsNotContainsISCopy.Remove(robot);
                }
            }

            if (robotsNotContainsISCopy.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            else
            {
                IRobot robot = robotsNotContainsISCopy[0];

                supplements.RemoveByName(supplementTypeName);

                if (supplementTypeName == "SpecializedArm")
                {
                    robot.InstallSupplement(new SpecializedArm());
                }
                else
                {
                    robot.InstallSupplement(new LaserRadar());
                }

                return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
            }
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> equalRobots = new();

            foreach (var robot in robots.Models())
            {
                foreach (var IS in robot.InterfaceStandards)
                {
                    if (IS == intefaceStandard)
                    {
                        equalRobots.Add(robot);
                    }
                }
            }

            if (equalRobots.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            equalRobots = equalRobots
                .OrderByDescending(r => r.BatteryLevel)
                .ToList();

            int sum = 0;
            int count = 0;

            foreach (var robot in equalRobots)
            {
                sum += robot.BatteryLevel;
            }

            if (sum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sum);
            }
            else
            {

                foreach (var robot in equalRobots)
                {
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {
                        robot.ExecuteService(totalPowerNeeded);
                        count++;
                        break;
                    }
                    else
                    {
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        count++;
                    }
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, count);
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robotsToFeed = new();

            int batteryLevelIsLessThen50Persent = 0;
            int count = 0;

            foreach (var robot in robots.Models())
            {
                if (robot.Model == model)
                {
                    robotsToFeed.Add(robot);
                }
            }

            foreach (var robot in robotsToFeed)
            {
                batteryLevelIsLessThen50Persent = robot.BatteryCapacity / 2;

                if (robot.BatteryLevel <= batteryLevelIsLessThen50Persent)
                {
                    robot.Eating(minutes);
                    count++;
                }
            }

            return string.Format(OutputMessages.RobotsFed, count);
        }

        public string Report()
        {
            List<IRobot> sortedRobots = robots.Models().ToList();

            sortedRobots = sortedRobots
                .OrderBy(r => r.BatteryCapacity)
                .OrderByDescending(r => r.BatteryLevel)
                .ToList();

            StringBuilder sb = new();

            foreach (var robot in sortedRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
