read -p "Install the report generator tool? 1 to install, ENTER to skip:" answer
if [ -n $answer ] && [ $answer -eq 1 ]
then
    echo "Installing tool..."
    dotnet tool install --global dotnet-reportgenerator-globaltool --version 4.6.7
else
    echo "Skipping installation."
fi 
echo Core prep ...
targets=("ExpressionPowerTools.Core" \
    "ExpressionPowerTools.Serialization" \
    "ExpressionPowerTools.Serialization.EFCore.AspNetCore" \
    "ExpressionPowerTools.Serialization.EFCore.Http")
for target in "${targets[@]}";
do
	echo $target
    cd "test/$target.Tests"
    if [ -e "TestDocResults" ]
    then
        rm -r "TestDocResults"
    fi
    dotnet test --configuration Release --logger trx --collect:"XPlat Code Coverage" --results-directory TestDocResults
    echo "Generating reports..."
    cd TestDocResults
    reportgenerator -reports:**/*.xml --targetdir:reports -reporttypes:Badges\;TextSummary -assemblyfilters:+$target
    cd ../../..
done
echo Build parser ...
cd tools/ExpressionPowerTools.Utilities.TestResultsParser
dotnet build --configuration Release
cd bin/Release/netcoreapp3.1
dotnet ExpressionPowerTools.Utilities.TestResultsParser.dll
cd ../../../../.. 
echo Done!