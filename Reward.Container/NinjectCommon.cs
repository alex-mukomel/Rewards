using Ninject;
using Rewards.BLL;
using Rewards.BLL.Interface;
using Rewards.DAL;
using Rewards.DAL.Interface;

namespace Rewards.Container
{
    public static class NinjectCommon
    {
        #region Fields
        public static IKernel Kernel { get; } = new StandardKernel();
        #endregion

        #region Methods
        public static void Registration()
        {
            Kernel.Bind<IMedalDao>().To<MedalDao>();
            Kernel.Bind<IPersonDao>().To<PersonDao>();
            Kernel.Bind<IRewardDao>().To<RewardDao>();

            Kernel.Bind<IMedalsLogic>().To<MedalsLogic>();
            Kernel.Bind<IPeopleLogic>().To<PeopleLogic>();
            Kernel.Bind<IRewardsLogic>().To<RewardsLogic>();
        }
        #endregion
    }
}
