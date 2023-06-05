using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefense
{
    internal class Pig : Tower
    {
        public Pig(Tile position)
        {
            name = "Pig";
            texture = Resource1.pig;
            this.position = position;
            cost = 100;
            maxCooldown = 1.0;

            selectMethod = new SniperSelect(3.0, position);
            damageMethod = new NormalDamage(5.0);
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
            name = "Snowball";
            texture= Resource1.snowball;
            this.position = position;
            cost = 200;
            maxCooldown = 1.3;

            selectMethod = new SniperSelect(3.5, position);
            damageMethod = new FreezeSingleDamage(4.0);
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
            name = "Napoleon";
            texture = Resource1.napoleon;
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
            name = "Boxer";
            texture = Resource1.boxer;
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
            name = "Hedgehog";
            texture = Resource1.hedgehog;
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