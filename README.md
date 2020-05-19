# UnitCommitmentProblem
The Unit Commitment Problem is a problem that must be solved frequently by a power provider. The goal is to find which units (PowerPlant) will be used to meet the forecasted demand with the lowest cost and under some constraints. The most advanced method used for that mathematical problem is the LR methods. 


# Solutions
The first logical solution that I tried was an intuitive solution (I didn't know the mathematical problem) so I just wanted to try a first approach without reading anything.
But if you are looking to find a proper solution and especially if the problem is more detailled you have to follow one of these resolution method:
- Priority List Method
- Branch and bounds method
- Dynamic Programming Method
- Lagrangian Relaxation (LR) method


# Get Started
Clone the repository and then open it. You can use either docker or directly run the program in VS. If you run docker it will be running on the port that you've set as "ServicePort" but if you run the program it will run on the port 8888 (https://localhost:8888/swagger/index.html).

# Web API
The program is only a Web API that receives a payload as below:
{
  "load": 480,
  "fuels": {
    "gas": 13.4,
    "kerosine": 50.8,
    "co2": 20,
    "wind": 60
  },
  "powerplants": [
    {
      "name": "gasfiredbig1",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredbig2",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredsomewhatsmaller",
      "type": "gasfired",
      "efficiency": 0.37,
      "pmin": 40,
      "pmax": 210
    },
    {
      "name": "tj1",
      "type": "turbojet",
      "efficiency": 0.3,
      "pmin": 0,
      "pmax": 16
    },
    {
      "name": "windpark1",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 150
    },
    {
      "name": "windpark2",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 36
    }
  ]
}

# Return the powerplant list with the production amount to realize for each as below:
[
  {
    "powerplantName": "windpark1",
    "production": 150
  },
  {
    "powerplantName": "windpark2",
    "production": 36
  },
  {
    "powerplantName": "gasfiredbig1",
    "production": 166
  },
  {
    "powerplantName": "gasfiredbig2",
    "production": 332
  },
  {
    "powerplantName": "gasfiredsomewhatsmaller",
    "production": 0
  },
  {
    "powerplantName": "tj1",
    "production": 0
  }
]

# Why ?
I tried to solve the Unit Commitment problem when I was doing a code challenge for Engie (Belgium) - https://github.com/gem-spaas/powerplant-coding-challenge

# Who ?
I'm Jamal Abdelkhalek, A Full-Stack .Net Developer. (https://www.linkedin.com/in/jamal-digital-developer/)
