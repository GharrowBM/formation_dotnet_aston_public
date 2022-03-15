using Microsoft.AspNetCore.SignalR;

namespace TP06.Hubs
{
    public class GameHub : Hub
    {
        private Random _random;

        public GameHub()
        {
            _random = new Random();
        }

        public async Task MakeNewCharacteristicRoll(string characterName, string charType, int charValue, string modifier)
        {
            if (string.IsNullOrEmpty(modifier)) modifier = "0";
            int rollResult = Math.Max(1, _random.Next(0,21) + charValue + Convert.ToInt32(modifier));

            Clients.All.SendAsync("NewCharacteristicsRoll", characterName, charType, rollResult);
        }

        public async Task MakeNewNormalRoll(string characterName, int diceType, string modifier)
        {
            if (string.IsNullOrEmpty(modifier)) modifier = "0";
            int rollResult = Math.Max(1, _random.Next(0,diceType + 1) + Convert.ToInt32(modifier));

            Clients.All.SendAsync("NewNormalRoll", characterName, diceType, rollResult);
        }

        public async Task MakeNewAttackRoll(string characterName, int diceType, string modifier, string target)
        {
            if (string.IsNullOrEmpty(modifier)) modifier = "0";
            if (string.IsNullOrEmpty(target)) target = "0";
            int rollResult = Math.Max(1, _random.Next(0, diceType + 1) + Convert.ToInt32(modifier));

            int armorClass = target == "1" ? 14 : target == "2" ? 8 : target == "3" ? 15 : 10;
            bool hasTouched = rollResult >= armorClass;

            Clients.All.SendAsync("NewAttackRoll", characterName, target, hasTouched);
        }
    }
}
