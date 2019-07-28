export TERM=xterm
ppath=$(pwd)
unitybin="/Applications/Unity/Hub/Editor/2018.3.14f1/Unity.app"
open -a Unity --args -quit -batchmode -logFile buildLinux.log -projectPath $ppath -executeMethod Builder.buildLinux
