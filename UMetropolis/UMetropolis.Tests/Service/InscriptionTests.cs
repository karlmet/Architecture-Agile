using System.Collections.Generic;
using Xunit;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using UMetropolis.Domaine;
using UMetropolis.Infrastructure;
using UMetropolis.Service;

namespace UMetropolis.Tests.Service
{
    public class InscriptionTests
    {
        private Fixture _fix;
        private IDepotCours _mockDepotCours;
        private IServiceSecurite _mockServiceSecurite;
        private InscriptionService _instanceService;

        public InscriptionTests()
        {
            _fix = new Fixture();
            _mockDepotCours = Substitute.For<IDepotCours>();
            _mockServiceSecurite = Substitute.For<IServiceSecurite>();
            _instanceService = new InscriptionService(_mockDepotCours, _mockServiceSecurite);
        }

        [Fact]
        public void VerifierAccess_EtudiantValide_AccessOK()
        {
            //--arranger
            var etudiant = _fix.Create<Etudiant>();
            _mockServiceSecurite.EstUtilisateurAuthentifie(Arg.Is(etudiant.Id)).Returns(true);
            _mockServiceSecurite.AccesEtudiant(Arg.Is(etudiant.Id)).Returns(true);

            //--agir
            var access = _instanceService.VerifierAccess(etudiant.Id);

            //--assertion
            access.Should().BeTrue();
        }


        [Fact]
        public void ObtenirListeCours_EtudiantAccessValide_ListeAvecElements()
        {                 
            //--arranger
            var etudiant = _fix.Create<Etudiant>();
            _mockDepotCours.ObtenirCoursEtudiantDroit(Arg.Is(etudiant.Id)).Returns(_fix.Create<List<Cours>>());

            //--agir
            var listeCours = _instanceService.ObtenirListeCours(etudiant.Id);

            //--assertion
            listeCours.Should().NotBeEmpty();
        }


    }
}
