# LuccaTechnicalTest
Technical test for Lucca, API Back. Onion Structure and XUnit

# Pre-requisite
I added a docker-compose in order to easily test the app. You'll need Docker : https://www.docker.com/products/docker-desktop/
There is two container : one for the app, one for the database.

# Goal
You'll find the goal of the project here : https://github.com/LuccaSA/Cleemy.RecruitmentTest/tree/main/back/senior

## Entities 
Une dépense est caractérisée par :

Un utilisateur (personne qui a effectué l'achat)
Une date
Une nature (valeurs possibles : Restaurant, Hotel et Misc)
Un montant et une devise
Un commentaire
Un utilisateur est caractérisé par :

Un nom de famille
Un prénom
Une devise dans laquelle il effectue ses achats

## Rules for Expense creation 

Une dépense ne peut pas avoir une date dans le futur,
Une dépense ne peut pas être datée de plus de 3 mois,
Le commentaire est obligatoire,
Un utilisateur ne peut pas déclarer deux fois la même dépense (même date et même montant),
La devise de la dépense doit être identique à celle de l'utilisateur.

## Seed Data 
### User
```json
[
  {
    "id": "c45f61df-73b5-4d23-991a-29e513f7da4f",
    "fullName": "Romanova  Natasha ",
    "currency_ISO": "RUB"
  },
  {
    "id": "bf57ab6d-fd05-4b64-a878-3867c90f6fad",
    "fullName": "Anthony Stark",
    "currency_ISO": "USD"
  }
]
```

## Libraries Used

MOQ / EF CORE

# Limitation
As I am learning docker with this project, I didn't manage to integrate test in the DockerFile.
```text
FROM build as test
WORKDIR "/src/Lucca.UnitTest"
RUN dotnet test
```
Didn't work. I'll figure how to do it in the future, probably.
