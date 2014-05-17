using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FMEditorLive.FMObjects;
using FMUtility.Core.Extensions;
using FMUtility.Models;
using Humanizer;

namespace FMUtility.Data.Proxies
{
    public class PlayerModelProxy : PlayerModel
    {
        private readonly Player _player;
        private List<AttributeModel> _goalkeeping;
        private List<AttributeModel> _hidden;
        private List<AttributeModel> _mental;
        private List<AttributeModel> _physical;
        private List<Position> _positions;
        private List<AttributeModel> _technical;

        public PlayerModelProxy(Player player)
        {
            _player = player;
        }

        public override List<AttributeModel> Hidden
        {
            get { return _hidden ?? (_hidden = MapHidden(_player.PlayingAttribute)); }
            set { _hidden = value; }
        }

        public override List<AttributeModel> GoalKeeping
        {
            get { return _goalkeeping ?? (_goalkeeping = MapGoalkeeping(_player.PlayingAttribute)); }
            set { _goalkeeping = value; }
        }

        public override List<AttributeModel> Mental
        {
            get { return _mental ?? (_mental = MapMental(_player.PlayingAttribute)); }
            set { _mental = value; }
        }

        public override List<AttributeModel> Physical
        {
            get { return _physical ?? (_physical = MapPhysical(_player.PlayingAttribute)); }
            set { _physical = value; }
        }

        public override List<Position> Positions
        {
            get { return _positions ?? (_positions = MapPositions(_player.PlayingAttribute)); }
            set { _positions = value; }
        }

        public override List<AttributeModel> Techincal
        {
            get { return _technical ?? (_technical = MapTechnical(_player.PlayingAttribute)); }
            set { _technical = value; }
        }

        private List<AttributeModel> MapGoalkeeping(PlayingAttributes attributes)
        {
            return new List<AttributeModel>
            {
                Map(p => p.AerialAbility, attributes.AerialAbility),
                Map(p => p.CommandOfArea, attributes.CommandOfArea),
                Map(p => p.Communication, attributes.Communication),
                Map(p => p.Eccentricity, attributes.Eccentricity),
                Map(p => p.FirstTouch, attributes.FirstTouch),
                Map(p => p.FreeKickTaking, attributes.FreeKickTaking),
                Map(p => p.Handling, attributes.Handling),
                Map(p => p.Kicking, attributes.Kicking),
                Map(p => p.OneOnOnes, attributes.OneOnOnes),
                Map(p => p.PenaltyTaking, attributes.PenaltyTaking),
                Map(p => p.Reflexes, attributes.Reflexes),
                Map(p => p.RushingOut, attributes.RushingOut),
                Map(p => p.TendencyToPunch, attributes.TendencyToPunch),
                Map(p => p.Throwing, attributes.Throwing)
            };
        }

        private List<AttributeModel> MapHidden(PlayingAttributes attributes)
        {
            return new List<AttributeModel>
            {
                Map(p => p.Consistency, attributes.Consistency),
                Map(p => p.Dirtiness, attributes.Dirtiness, true),
                Map(p => p.ImportantMatches, attributes.ImportantMatches),
                Map(p => p.InjuryProneness, attributes.InjuryProneness, true),
                Map(p => p.Versatility, attributes.Versatility)
            };
        }

        private List<AttributeModel> MapMental(PlayingAttributes attributes)
        {
            return new List<AttributeModel>
            {
                Map(p => p.Aggression, attributes.Aggression),
                Map(p => p.Anticipation, attributes.Anticipation),
                Map(p => p.Bravery, attributes.Bravery),
                Map(p => p.Composure, attributes.Composure),
                Map(p => p.Concentration, attributes.Concentration),
                Map(p => p.Creativity, attributes.Creativity),
                Map(p => p.Decisions, attributes.Decisions),
                Map(p => p.Determination, attributes.Determination),
                Map(p => p.Flair, attributes.Flair),
                Map(p => p.Influence, attributes.Influence),
                Map(p => p.OffTheBall, attributes.OffTheBall),
                Map(p => p.Positioning, attributes.Positioning),
                Map(p => p.Teamwork, attributes.Teamwork),
                Map(p => p.WorkRate, attributes.WorkRate)
            };
        }

        private List<AttributeModel> MapPhysical(PlayingAttributes attributes)
        {
            return new List<AttributeModel>
            {
                Map(p => p.Acceleration, attributes.Acceleration),
                Map(p => p.Agility, attributes.Agility),
                Map(p => p.Balance, attributes.Balance),
                Map(p => p.Jumping, attributes.Jumping),
                Map(p => p.NaturalFitness, attributes.NaturalFitness),
                Map(p => p.Pace, attributes.Pace),
                Map(p => p.Stamina, attributes.Stamina),
                Map(p => p.Strength, attributes.Strength)
            };
        }

        private List<AttributeModel> MapTechnical(PlayingAttributes attributes)
        {
            return new List<AttributeModel>
            {
                Map(p => p.Corners, attributes.Corners),
                Map(p => p.Crossing, attributes.Crossing),
                Map(p => p.Dribbling, attributes.Dribbling),
                Map(p => p.Finishing, attributes.Finishing),
                Map(p => p.FirstTouch, attributes.FirstTouch),
                Map(p => p.FreeKickTaking, attributes.FreeKickTaking),
                Map(p => p.Heading, attributes.Heading),
                Map(p => p.LongShots, attributes.LongShots),
                Map(p => p.LongThrows, attributes.LongThrows),
                Map(p => p.Marking, attributes.Marking),
                Map(p => p.Passing, attributes.Passing),
                Map(p => p.PenaltyTaking, attributes.PenaltyTaking),
                Map(p => p.Tackling, attributes.Tackling),
                Map(p => p.Technique, attributes.Technique)
            };
        }

        private List<Position> MapPositions(PlayingAttributes attributes)
        {
            return new List<Position>
            {
                Map(p => p.GK, attributes.GK, Area.Goalkeeping),
                Map(p => p.SW, attributes.SW, Area.Defending),
                Map(p => p.DL, attributes.DL, Area.Defending),
                Map(p => p.DC, attributes.DC, Area.Defending),
                Map(p => p.DR, attributes.DR, Area.Defending),
                Map(p => p.WBL, attributes.WBL, Area.Defending),
                Map(p => p.DM, attributes.DM, Area.Midfield),
                Map(p => p.WBR, attributes.WBR, Area.Defending),
                Map(p => p.ML, attributes.ML, Area.Midfield),
                Map(p => p.MC, attributes.MC, Area.Midfield),
                Map(p => p.MR, attributes.MR, Area.Midfield),
                Map(p => p.AML, attributes.AML, Area.Midfield),
                Map(p => p.AMC, attributes.AMC, Area.Midfield),
                Map(p => p.AMR, attributes.AMR, Area.Midfield),
                Map(p => p.ST, attributes.ST, Area.Attacking)
            };
        }

        private Position Map(Expression<Func<PlayingAttributes, object>> property, int value, Area area)
        {
            return new Position
            {
                Area = area,
                Name = property.GetPropertyName().Titleize(),
                Value = value
            };
        }

        private AttributeModel Map(Expression<Func<PlayingAttributes, object>> property, int value,
            bool isNegative = false)
        {
            return new AttributeModel
            {
                IsNegative = isNegative,
                Name = property.GetPropertyName().Titleize(),
                Value = value
            };
        }
    }
}