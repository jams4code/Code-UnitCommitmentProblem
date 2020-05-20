# UnitCommitmentProblem

The Unit Commitment Problem is a problem that must be solved frequently by a power provider. The goal is to find which units (PowerPlant) will be used to meet the forecasted demand with the lowest cost and under some constraints. The most advanced method used for that mathematical problem is the LR methods. 

In this case, we are using a simplified case: taking into account only the fuel costs, the powerplant efficiency, the wind % and the co2 cost.

# Solution

The first logical solution that I tried was intuitive because I didn't know the mathematical problem, so I just wanted to try the first approach without reading anything.
I do have an interest in engineering problems and complex algorithmic because even if I'm passioned about programming, I do have a mathematical background since I wanted to do Civil Engineering studies.
I followed advanced mathematical courses to be prepared for the entry exam (that I succeed by the way), and I was in the Mathematics section in Secondary school.
I didn't try to implement a known approach as Dynamic programming or the LR method because I don't think that will reflect my thinking and my methodology.
Besides, it would not be a challenge anymore if I had to use a known approach; it would only be an implementation of a mathematical solution.

# Other solutions
if you are looking to find a proper solution and especially if the problem is more detailed, you have to follow one of these resolution methods:
- Priority List Method
- Branch and bounds method
- Dynamic Programming Method
- Lagrangian Relaxation (LR) method


# Get Started
- Clone the repository and then open it
- You can run it either through docker or directly run the Web API in VisualStudio (https://localhost:8888/swagger/index.html)
(If you run it through docker make sure that you have docker running - It runs through a Linux container)
- You can access the swagger interface to interact with the API
- You can then make a POST request by following the JSON format as below

(I have also publish an instance of the API in the cloud using Azure. You can access it here: https://gem-spaas-powerplant-coding-challenge.azurewebsites.net/swagger/index.html ).

# Web API

The program is only a Web API that receives a payload as below in the endpoint /productionplan:
{
  "load": 910,
  "fuels":
  {
    "gas(euro/MWh)": 13.4,
    "kerosine(euro/MWh)": 50.8,
    "co2(euro/ton)": 20,
    "wind(%)": 60
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

# Response
- Return the powerplant list with the production amount to realize for each as below:
[
  {
    "powerplantName": "windpark1",
    "production": 90
  },
  {
    "powerplantName": "windpark2",
    "production": 21.6
  },
  {
    "powerplantName": "gasfiredbig1",
    "production": 460
  },
  {
    "powerplantName": "gasfiredbig2",
    "production": 338.4
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

# Why?
I tried to solve the Unit Commitment problem when I was doing a code challenge for Engie (Belgium) - https://github.com/gem-spaas/powerplant-coding-challenge

# Who?
I'm Jamal Abdelkhalek, a highly motivated Full-Stack developer who's looking for new challenges in his day to day job. (https://www.linkedin.com/in/jamal-digital-developer/)

