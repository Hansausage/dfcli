﻿## dfcli
### command line tool for managing installations (instances) of dwarf fortress for Linux/Windows

create new simple instance of dwarf fortress: `dfcli -n "my instance"`

launch an instance: `dfcli myinstance`

for help run `dfcli -h`

### Building

Run build.sh - requires mono/.NET framework including a c# compiler and msbuild



dfcli creates instances in `/home/user/.local/share/dfcli` on linux and `AppData` on Windows
