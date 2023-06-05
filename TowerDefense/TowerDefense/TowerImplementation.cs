using System.Collections.Generic;

namespace TowerDefense
{
    internal class Pig : Tower
    {
        public Pig(Tile position)
        {
            this.position = position;
            cost = 100;
            maxCooldown = 1.0;

            selectMethod = new SniperSelect(3.0, position);
            damageMethod = new NormalDamage(4.0);
        }

        public override void select(List<Enemy> enemies, double delta_t)
        {
            cooldownSelect(enemies, delta_t);
        }
    }

    internal class Snowball : Tower
    {
        public Snowball(Tile position)
        {
            this.position = position;
            cost = 200;
            maxCooldown = 1.3;

            selectMethod = new SniperSelect(3.5, position);
            damageMethod = new FreezeSingleDamage(3.0);
        }

        public override void select(List<Enemy> enemies, double delta_t)
        {
            cooldownSelect(enemies, delta_t);
        }
    }

    internal class Napoleon : Tower
    {
        public Napoleon(Tile position)
        {
            this.position = position;
            cost = 300;
            maxCooldown = 1.5;

            selectMethod = new AreaSelect(2.5, position);
            damageMethod = new NormalDamage(3.0);
        }

        public override void select(List<Enemy> enemies, double delta_t)
        {
            cooldownSelect(enemies, delta_t);
        }
    }

    internal class Boxer : Tower
    {
        public Boxer(Tile position)
        {
            this.position = position;
            cost = 300;
            maxCooldown = 5.0;

            selectMethod = new SniperSelect(5.0, position);
            damageMethod = new NormalDamage(20.0);
        }

        public override void select(List<Enemy> enemies, double delta_t)
        {
            cooldownSelect(enemies, delta_t);
        }
    }

    internal class Hedgehog : Tower
    {
        public Hedgehog(Tile position)
        {
            this.position = position;
            cost = 200;

            selectMethod = new AreaSelect(2.5, position);
            damageMethod = new ContinuousDamage(2.0);
        }

        public override void select(List<Enemy> enemies, double delta_t)
        {
            continuousSelect(enemies);
        }
    }
}