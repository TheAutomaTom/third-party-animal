# ThirdPartyAnimal🌹
```
> ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄/;~-..__-=
> ███ ─▄─▄─/─█─█▄─██▄─▄▄▀█▄─▄▄▀██████/▄─
> ██████─███─▄─██─███─▄─▄██─██─████████─
> █████▄▄███▄█▄█▄▄▄██▄█▄▄██▄▄▄▄████████
> ██▄─▄▄─██▀▄─▄█▄─▄▄▀█─▄─▄─█▄─█─▄█████
> ███─▄▄▄██─▀─███─▄─▄███─████▄─▄██████
> ███/█████/█▄▄██▄█▄▄███▄▄███▄/███████▄▄
> █▀▄─▄█▄─▀█▄─▄█▄─██▄─▀█▀─▄██▀▄─▄█▄─▄███▄─~
> █─▀─███─█▄▀─███─███─█▄█─███─▀─███─██▀█▄▄▄─
> ▄▄█▄▄█▄▄▄██▄▄█▄▄▄█▄▄▄█▄▄▄█▄▄█▄▄\▄▄▄▄▄█▄^─.
> Our voter data aggrigator 2022
```

###### Intent
- To make public records voter data more accessible to data scientists... _and maybe help get me a job._

###### Present Coverage
- **Florida** has been my primary focus as I add new features.  It's fairly simple and the files are lightweight.
    - Florida voting records must be acquired by postal service.  More info: https://dos.myflorida.com/elections/data-statistics/voter-registration-statistics/voter-extract-disk-request/
- **North Carolina** provides a lot more history data than FL, and I intend to catch it up the FL's features, as they are ready for release.  
    - More info: https://www.ncsbe.gov/results-data/voter-registration-data
- **Georgia** charges an extremely unreasonable $250 fee to citizen requesting voter registration data, so it has not yet been incorporated.  
- *I'd be happy to work toward adding any states contributors may take special interest in.*
    
## 🌹 Project Summaries
#### `3PA.UI` _User Facing, Browser-Based Web App_
- **Vue 3** _with..._
    - **Vuex** stores
    - **Decorators** for class and props
    - The native **router** & **eventbus** are set up and working
    - _No styling or component library has been adopted, yet._

###### `3PA.Data.SQL` _Raw Data_
- EF Core 
    - Commit publicly available voting records to local Sql.
- Contains complete copy of available public records in three tables:
    - `Voters` individual identification data.
    - `Histories` of voters registered in the above table.
    - `OrphanHistories` where the assigned voter registration number is not already recorded.  

###### `3PA.Queue` _Task Queue_
- RabbitMq 
    - ~~allows UI to line up public records to be read into Sql.~~
    - This project is not yet deployed.

## 🌹 To-do's & Intentions
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

## 🌹 How to get started
_The projects are basically plug & play..._

`3PA.API` _Data Services_

I have been experimenting with RabbitMq, but you shouldn't need that installed to debug, at present.
1. In Visual Studio, open `ThirdPartyAnimal.sln`
2. Begin debugging (all the local launch and app settings are included, at present).
3. Begin by posting some of the included sample data, such as:
- A small county's voter identities file `20211207_VoterDetail\LAF_20211207.txt`
- followed by their histories `20211207_VoterHistory\LAF_H_20211207.txt`
- _You may follow larger files' progress in the console window._

`3PA.UI` _User Facing, Browser-Based Web App_

You will need Node.js installed to run.
1. In VsCode, open folder `...\3pa.ui\src`
1. In the terminal, run `yarn` to update Node packages
1. Calls from the "Api Phonebook" test harness should succeed

🌹 _More to come as the project developes!_

