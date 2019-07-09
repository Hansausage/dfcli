## dfcli
### command line tool for managing installations (instances) of dwarf fortress for Linux/Windows

create new simple instance of dwarf fortress: `dfcli -n myinstance`

launch an instance: `dfcli myinstance`

for help run `dfcli -h`

Note: Not all features are implemented, and this tool is in a very early stage. Not all arguments listed in the help are applicable yet.

### Currently implemented features

* Will create instances of dwarf fortress, including downloading a specified version of the game and generating an instance.json
* Launching instances
* Deleting instances

### Planned features

* Downloading and launching specified utilities such as dfhack, dwarf therapist, etc.
* Downloading and using tilesets or using a tileset specified from an archive
* Downloading and using mods?

### In progress

* Backing up and adding instances from an archive
* Adding existing dwarf fortress installations for use with dfcli


### Building

Run `./build.sh` - requires mono/.NET framework including a c# compiler and msbuild

dfcli creates instances in `/home/user/.local/share/dfcli` on linux and `AppData` on Windows
