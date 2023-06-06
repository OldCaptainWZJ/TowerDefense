using System.Collections.Generic;

namespace TowerDefense
{
    internal class Leopard : Enemy
    {
        public Leopard()
        {
            texture = Resource1.leopard;

            HP = maxHP = 15.0;
            attack = 20;
            speed = defaultSpeed = 2.5;
            reward = 10;

            status = new List<double>();
            for (int i = 0; i < (int)StatusEffect.TotalCount; i++)
            {
                status.Add(0.0);
            }

            initHurtTimer();
        }
        public override void move(double delta_t)
        {
            defaultMove(delta_t);
        }
        public override void statusEffect(double delta_t)
        {
            defaultStatusEffect(delta_t);
        }

        public override void dealtDamage(double val)
        {
            defaultDealtDamage(val);
        }
        public override void dealtStatusEffect(StatusEffect type, double val)
        {
            defaultDealtStatusEffect(type, val);
        }
    }

    internal class Toad : Enemy
    {
        private double moveCountdown = 1.5;
        public Toad()
        {
            texture = Resource1.toad;

            HP = maxHP = 20.0;
            attack = 20;
            speed = defaultSpeed = 2.0;
            reward = 10;

            status = new List<double>();
            for (int i = 0; i < (int)StatusEffect.TotalCount; i++)
            {
                status.Add(0.0);
            }

            initHurtTimer();
        }
        public override void move(double delta_t)
        {
            if (this.reachedBase()) return;

            moveCountdown -= delta_t;
            if (moveCountdown < 0.0)
            {
                moveCountdown += 3.0;
                movingStage += 2;
                if (this.reachedBase()) return;

                initPosition(path[movingStage]);
            }
        }
        public override void statusEffect(double delta_t)
        {
            //immunity
            //defaultStatusEffect(delta_t);
        }

        public override void dealtDamage(double val)
        {
            defaultDealtDamage(val);
        }
        public override void dealtStatusEffect(StatusEffect type, double val)
        {
            //immunity
            //defaultDealtStatusEffect(type, val);
        }
    }

    internal class Snail : Enemy
    {
        public Snail()
        {
            texture = Resource1.snail;

            HP = maxHP = 50.0;
            attack = 20;
            speed = defaultSpeed = 0.5;
            reward = 10;

            status = new List<double>();
            for (int i = 0; i < (int)StatusEffect.TotalCount; i++)
            {
                status.Add(0.0);
            }

            initHurtTimer();
        }
        public override void move(double delta_t)
        {
            defaultMove(delta_t);
        }
        public override void statusEffect(double delta_t)
        {
            defaultStatusEffect(delta_t);
        }

        public override void dealtDamage(double val)
        {
            defaultDealtDamage(val);
        }
        public override void dealtStatusEffect(StatusEffect type, double val)
        {
            defaultDealtStatusEffect(type, val);
        }
    }
    internal class Mouse : Enemy
    {
        public Mouse()
        {
            texture = Resource1.mouse;

            HP = maxHP = 15.0;
            attack = 20;
            speed = defaultSpeed = 1.0;
            reward = 10;

            status = new List<double>();
            for (int i = 0; i < (int)StatusEffect.TotalCount; i++)
            {
                status.Add(0.0);
            }

            initHurtTimer();
        }
        public override void move(double delta_t)
        {
            defaultMove(delta_t);
        }
        public override void statusEffect(double delta_t)
        {
            defaultStatusEffect(delta_t);
        }

        public override void dealtDamage(double val)
        {
            defaultDealtDamage(val);
        }
        public override void dealtStatusEffect(StatusEffect type, double val)
        {
            defaultDealtStatusEffect(type, val);
        }
    }

    internal class Scorpion : Enemy
    {
        public Scorpion()
        {
            texture = Resource1.scorpion;

            HP = maxHP = 20.0;
            attack = 50;
            speed = defaultSpeed = 1.5;
            reward = 10;

            status = new List<double>();
            for (int i = 0; i < (int)StatusEffect.TotalCount; i++)
            {
                status.Add(0.0);
            }

            initHurtTimer();
        }
        public override void move(double delta_t)
        {
            defaultMove(delta_t);
        }
        public override void statusEffect(double delta_t)
        {
            defaultStatusEffect(delta_t);
        }

        public override void dealtDamage(double val)
        {
            defaultDealtDamage(val);
        }
        public override void dealtStatusEffect(StatusEffect type, double val)
        {
            defaultDealtStatusEffect(type, val);
        }
    }
}