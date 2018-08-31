using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFixture;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Rapports;
using UMetropolis.Pegase.Rapports;
using NSubstitute;
using UMetropolis.Domaine;
using Xunit;


namespace UMetropolis.Tests
{
    public class RapportCoursTests
    {

        private Fixture _fix;

        public RapportCoursTests()
        {
            _fix = new Fixture();
            _fix.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fix.Behaviors.Remove(b));
            _fix.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public void Test()
        {
            //--arranger
         
            var mockDepotCours = Substitute.For<Pegase.Rapports.IDepotCours>();
            var listeCoursConfirm = _fix.Create<List<Cours>>();
            mockDepotCours.ObtenirCoursConfirme().Returns(listeCoursConfirm);
            var mockServiceFacturation = Substitute.For<IServiceFacturation>();
            var instanceTest = new ConfirmationCours(mockServiceFacturation, mockDepotCours);


            //--agir
            instanceTest.ConcilierFacturation();

            //--assertion
            mockDepotCours.Received().ObtenirCoursConfirme();
            mockServiceFacturation.Received().FacturerCoursConfirmer(Arg.Any<List<Cours>>());


        }
    }
}
