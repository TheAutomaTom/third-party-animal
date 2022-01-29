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

###### Present Coverage
**Florida** has been my primary focus as I add new features.
**North Carolina** provides a lot more history data than FL, and I intend to catch it up the FL's features, as I feel they are ready for release.
*Further additions*
    - **Georgia** charges an extremely unreasonable $250 fee to citizen requesting voter registration data.  If you have an interest in sharing data you have already obtained, or crowd-sourcing funding to share this data, please contact `TheAutomaTom@gmail.com`
    - I'd be happy to work toward adding any states folks may take interest in.  There is a huge variety in what is publicly available from each state.
    
## Project Summaries
###### `3PA.Queue` _Task Queue_
- Monitors RabbitMq server for queued tasks.

###### `3PA.Data.SQL` _Raw Data_
- Uses EF Core to commit publicly available voting records to local Sql.
- Contains complete copy of available public records in three tables:
    - `Voters` individual identification data.
    - `Histories` of voters registered in the above table.
    - `OrphanHistories` where the assigned voter registration number is not already recorded.  

## To-do's & Intentions
#### Public Records Collection
- Add Messaging service to line up queues of public records, so I don't have to feed them in one at a time.  
    - *RabbitMQ or SignalR?*
- Add check to ensure a county's voter registration info was collected before reading histories, to avoid  mistaken "ophans."
- Add service to scan orphan histories for newly added voters in that county, and reconnect them in active histories.
- Add service to scan "other counties" to see if I can correlate a voter moving with their old histories.

#### Data Aggratation
- Use Elastic Search to compose efficient methods to identify likely third-party votes.

#### Front End Reporting UI
- To be Vue3 (Node Js) as a Spa
    - Add feature to query and compare Elastic Search indices
    - Add report visualizations.
        - *Maybe Kiabana offers this?*
    


Here are a few tips to get you started:

* Fuck the system.

* Take the cannoli.