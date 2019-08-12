namespace SportsPromo.Dados.Migrations
{
    using SportsPromo.Dominio.Modelos;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportsPromo.Dados.Contextos.SportsPromoContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportsPromo.Dados.Contextos.SportsPromoContexto context)
        {

            var generosPadrao = new List<Genero>()
            {
                new Genero()
                {
                    GeneroNome = "Masculino"
                },

                new Genero()
                {
                    GeneroNome = "Feminino"
                }
            };

            context.Generos.AddOrUpdate(e => e.GeneroNome, generosPadrao.ToArray());


        }
    }
}
