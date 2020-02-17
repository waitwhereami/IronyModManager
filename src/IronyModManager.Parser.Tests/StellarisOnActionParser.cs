﻿// ***********************************************************************
// Assembly         : IronyModManager.Parser.Tests
// Author           : Mario
// Created          : 02-17-2020
//
// Last Modified By : Mario
// Last Modified On : 02-17-2020
// ***********************************************************************
// <copyright file="StellarisOnActionParser.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using IronyModManager.Parser.Stellaris;
using IronyModManager.Tests.Common;
using Xunit;

namespace IronyModManager.Parser.Tests
{
    /// <summary>
    /// Class StellarisOnActionParser.
    /// </summary>
    public class StellarisOnActionParser
    {
        #region Methods

        /// <summary>
        /// Defines the test method CanParse_should_be_false_then_true.
        /// </summary>
        [Fact]
        public void CanParse_should_be_false_then_true()
        {
            var args = new CanParseArgs()
            {
                File = "common\\gamerules\\test.txt",
                GameType = "Stellaris"
            };
            var parser = new OnActionsParser();
            parser.CanParse(args).Should().BeFalse();
            args.File = "common\\on_actions\\test.txt";
            parser.CanParse(args).Should().BeTrue();
        }

        /// <summary>
        /// Defines the test method Has_valid_game_type.
        /// </summary>
        [Fact]
        public void Has_valid_game_type()
        {
            new OnActionsParser().GameType.Should().Be(Shared.Constants.GamesTypes.Stellaris);
        }

        /// <summary>
        /// Defines the test method Has_valid_parser_type.
        /// </summary>
        [Fact]
        public void Has_valid_parser_type()
        {
            new OnActionsParser().ParserType.Should().Be(Constants.StellarisOnActionsFlag);
        }

        /// <summary>
        /// Defines the test method Parse_should_yield_results.
        /// </summary>
        [Fact]
        public void Parse_should_yield_results()
        {
            DISetup.SetupContainer();

            var sb = new StringBuilder();
            sb.AppendLine(@"on_game_start = {");
            sb.AppendLine(@"    events = {");
            sb.AppendLine(@"        dmm_mod_1_flag.1");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            var args = new ParserArgs()
            {
                ContentSHA = "sha",
                Dependencies = new List<string> { "1" },
                File = "common\\on_actions\\fake.txt",
                Lines = sb.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
                ModName = "fake"
            };
            var parser = new OnActionsParser();
            var result = parser.Parse(args).ToList();
            result.Should().NotBeNullOrEmpty();
            result.Count().Should().Be(1);
            for (int i = 0; i < 1; i++)
            {
                result[i].ContentSHA.Should().Be("sha");
                result[i].Dependencies.First().Should().Be("1");
                result[i].File.Should().Be("common\\on_actions\\fake.txt");
                switch (i)
                {
                    case 0:
                        result[i].Code.Trim().Should().Be(sb.ToString().Trim());
                        result[i].Id.Should().Be("fake.txt");
                        break;

                    default:
                        break;
                }
                result[i].ModName.Should().Be("fake");
                result[i].Type.Should().Be("common\\on_actions");
            }
        }

        #endregion Methods
    }
}
