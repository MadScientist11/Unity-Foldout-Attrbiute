﻿using UnityEngine;

namespace QuizAndPuzzle.Foldout
{
    public class FoldoutAttribute : PropertyAttribute
    {
        private readonly string _name;

        public string Name => _name;
        
        public FoldoutAttribute(string name)
        {
            _name = name;
        }
    }
}