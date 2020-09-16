﻿using System;
using KMK.Model.Other;
using KMK.Model.Scorer;

namespace Controller.Game
{
    public class HealthScoreController
    {
        private Health _health;
        private Scorer _scorer;

        private float _oneHealthScore;
        private float _nextAmountScore;
        
        public event Action DisconnectFromObserver;

        public HealthScoreController(Health health, Scorer scorer, float oneHealthScore)
        {
            _health = health;
            _scorer = scorer;

            _oneHealthScore = oneHealthScore;
            _nextAmountScore = oneHealthScore;
        }
        
        public void Update(float deltaTime)
        {
            if (_scorer.CurrentScore >= _nextAmountScore)
            {
                _health.AddHealth();
                _nextAmountScore += _oneHealthScore;
            }
        }

    }
}