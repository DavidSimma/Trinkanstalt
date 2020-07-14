using System;
using System.Collections.Generic;
using System.Text;

namespace Trinkanstalt.models
{
    class Balance
    {
        private double _credit;
        private Dictionary<User, double> _owe = new Dictionary<User, double>();

        public int BalanceID { get; }
        public User BalanceHost { get; set; }
        public double Credit { get { return this._credit; } }
        public void increaseCredit(double amount)
        {
            _credit += amount;
        }
        public void decreaseCredit(double amount)
        {
            if (_credit - amount >= 0)
            {
                _credit -= amount;
            }
        }
        public void updateCreditAndOwe()
        {
            foreach(User u in Container.User)
            {
                foreach(User us in u.Balance.Owe.Keys)
                {
                    if (BalanceHost.Equals(us)) {
                        if (Owe.ContainsKey(u))
                        {
                            if (Owe[u] > u.Balance.Owe[us])
                            {
                                Owe[u] -= u.Balance.Owe[us];
                                decreaseCredit(u.Balance.Owe[us]);
                                u.Balance.decreaseCredit(Owe[u]);
                                u.Balance.Owe.Remove(us);
                            }
                            if (Owe[u] > u.Balance.Owe[us])
                            {
                                u.Balance.Owe[us] -= Owe[u];
                                decreaseCredit(u.Balance.Owe[us]);
                                u.Balance.decreaseCredit(Owe[u]);
                                Owe.Remove(u);
                            }
                            if (Owe[u] == u.Balance.Owe[us])
                            {
                                decreaseCredit(u.Balance.Owe[us]);
                                u.Balance.decreaseCredit(Owe[u]);
                                u.Balance.Owe.Remove(us);
                                Owe.Remove(u);
                            }
                        }
                    }
                }
            }
           
        }

        // i brauch no a methode wo ma, wenn ma di schulden abbezahlt hat (muss vom Leiher genehmigt werden) die Gutschriften vom Leiher verringert


        public Dictionary<User, double> Owe { get { return this._owe; } }
        public void increasOwe(User u, double amount)
        {
            if (_owe.ContainsKey(u))
            {
                _owe[u] += amount;
            }
            else
            {
                _owe.Add(u, amount);
            }
            
        }
        public bool decreaseOwe(User u, double amount)
        {
            if (_owe.ContainsKey(u))
            {
                if (_owe[u] - amount >= 0)
                {
                    _owe[u] -= amount;
                    return true;
                }
                if(_owe[u] - amount == 0)
                {
                    _owe.Remove(u);
                    return true;
                }
                return false;
            }
            return false;
        }



    }
}
