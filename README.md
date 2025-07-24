# Title: Creating a Foundation for Dynamic Difficulty Adjustment within PCG of Games using Imitation Learning
Authors: Navid Siamakmanesh, Mojtaba Vahidi-Asl, Aryan Ganji, Monireh Abdoos
Published in: Journal of Intelligent Computing Systems and Engineering (JICSE), Special Volume 2, Issue 2, January 2025
Link to paper: https://doi.org/10.48308/jicse.2025.239782.1071

This repository contains the implementation and research artifacts from our published work exploring a novel approach to Dynamic Difficulty Adjustment (DDA) in games that use Procedural Content Generation (PCG), powered by Imitation Learning.

We designed and implemented a 2D platformer game in Unity, in which enemy encounters are procedurally generated. Using Generative Adversarial Imitation Learning (GAIL) via Unity ML-Agents, we trained agent models to mimic real player behavior. These clones were then used to evaluate and adjust the difficulty of new, randomly generated levels.

# Key Components

Unity 2D platformer game with random enemy generation and level layout

ML-Agents integration to enable AI training and inference

Player demonstration data collected from 5 players

Three GAIL-based models trained to replicate player strategies

Clone evaluation system to predict player performance in new levels

DDA loop enabling developers to adjust content difficulty dynamically

# Results Summary
 Three models were created abd Two of them were successful in mimicking player performance, showing less than 10% average error in win rate.

Demonstrated potential for adaptive game balancing using clones in procedurally generated environments.

Foundation laid for further work on clone improvement and real-time difficulty adaptation.

# Technologies Used
Unity (C#)

Unity ML-Agents Toolkit (Python)

GAIL algorithm

PPO trainer

# Note
This project is a research prototype and currently a work in progress. As we may expand it into a full-fledged game in the future, some parts of the codebase are incomplete or experimental. You may encounter bugs or missing features.

We appreciate your interest and thank you for your understanding!
