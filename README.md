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
- **Florida** has been my primary focus as I add new features.  It's fairly simple and the files are lightweight.
    - Florida voting records must be acquired by postal service.  More info: https://dos.myflorida.com/elections/data-statistics/voter-registration-statistics/voter-extract-disk-request/
- **North Carolina** provides a lot more history data than FL, and I intend to catch it up the FL's features, as they are ready for release.  
    - More info: https://www.ncsbe.gov/results-data/voter-registration-data
- **Georgia** charges an extremely unreasonable $250 fee to citizen requesting voter registration data, so it has not yet been incorporated.  
- *I'd be happy to work toward adding any states contributors may take special interest in.*
    
## Project Summaries
#### `3PA.UI` _User Facing, Browser-Based Web App_
- Vue _with_ Vuex

###### `3PA.Queue` _Task Queue_
- RabbitMq 
    - allows UI to line up time public records to be read into Sql.

###### `3PA.Data.SQL` _Raw Data_
- EF Core 
    - Commit publicly available voting records to local Sql.
- Contains complete copy of available public records in three tables:
    - `Voters` individual identification data.
    - `Histories` of voters registered in the above table.
    - `OrphanHistories` where the assigned voter registration number is not already recorded.  

## To-do's & Intentions
#### Public Records Collection
- `Consumer` uses one repo for each state to read public records...
    - I can't seem to combine the repos into a generic
    - This may be because each repo makes decisions about Voter Identity vs History inside the same big method.
        - `PublicRecordBase` doesn't doo much but prevent using `object` in the repos
        - `IGeoData` is covering too much... some of the props are just "repo helpers"
        - `IPublicrecordEntryConfig` is half implemented...
    
    
    
- Add service to scan orphan histories for newly added voters in that county, and reconnect them in active histories.
- Add service to scan "other counties" to see if I can correlate a voter moving to their orphan histories *(low priority)*.

#### Data Aggregation
- Use Elastic Search to compose efficient methods to identify likely third-party votes.

    
