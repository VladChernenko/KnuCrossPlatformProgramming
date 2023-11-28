apt-get update && apt-get upgrade -y && apt-get install git curl wget nano tzdata

wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh

chmod +x ./dotnet-install.sh

./dotnet-install.sh --channel 7.0

export PATH=/root/.dotnet:$PATH

export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

########### Встановлення GMT+7 ###########

ln -fs /usr/share/zoneinfo/Asia/Bangkok /etc/localtime && dpkg-reconfigure -f noninteractive tzdata