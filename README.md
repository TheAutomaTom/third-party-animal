# ThirdPartyAnimal
```
▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄/;~-..__-=
███ ─▄─▄─/─█─█▄─██▄─▄▄▀█▄─▄▄▀██████/▄─
██████─███─▄─██─███─▄─▄██─██─████████─
█████▄▄███▄█▄█▄▄▄██▄█▄▄██▄▄▄▄████████
██▄─▄▄─██▀▄─▄█▄─▄▄▀█─▄─▄─█▄─█─▄█████
███─▄▄▄██─▀─███─▄─▄███─████▄─▄██████
███/█████/█▄▄██▄█▄▄███▄▄███▄/███████▄▄
█▀▄─▄█▄─▀█▄─▄█▄─██▄─▀█▀─▄██▀▄─▄█▄─▄███▄─~
█─▀─███─█▄▀─███─███─█▄█─███─▀─███─██▀█▄▄▄─
▄▄█▄▄█▄▄▄██▄▄█▄▄▄█▄▄▄█▄▄▄█▄▄█▄▄\▄▄▄▄█▄^─.
```
#### Project Summaries
###### `3PA.Data.SQL` _SQL Data Access Layer_
- Uses EF Core to commit publicly available voting records to local Sql.
- Contains complete copy of available public records in three tables:
    - `Voters` individual identification data.
    - `Histories` of voters registered in the above table.
    - `OrphanHistories` where the assigned voter registration number is not already recorded.  

#### Present Coverage by U.S. State
- **Florida** has been my primary focus as I add new features.
- **North Carolina** provides a lot more history data than FL, and I intend to catch it up the FL's features, as I feel they are ready for release.
    ###### Notes about future additions
    - **Georgia** charges an extremely unreasonable $250 fee to citizen requesting voter registration data.  If you have an interest in sharing data you have already obtained, or crowd-sourcing funding to share this data, please contact `TheAutomaTom@gmail.com`
    
    
Here are a few tips to get you started:

* Fuck the system.

* Take the cannoli