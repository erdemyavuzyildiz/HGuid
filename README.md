# HGuid
HashGuid Generator

Perhaps unnecessarily lengthened, improved version of Guid.
Increased resistance for collusion when used in parallel distributed environments.

#Algorithm

##Random Number between 000000000, 999999999, generated from a Random generator seeded with current UTCNow timestamp ticks Hashcode
###Increases the resolution with time based random number generation.
var rand = new Random(DateTimeOffset.UtcNow.Ticks.GetHashCode());
var randomNumber = rand.Next(000000000, 999999999);

##Current processId of the machine 
###Most likely every proccess will have different process id.
var proccessId = Process.GetCurrentProcess().Id;

##Current machine name
###Most likely every machine will have a different machine name and machine names can be purposely changed if needed.
var machineName = Environment.MachineName;

##Cpu ticks elapsed since preperation of the above information
###Different cpu's or virtual machines under load will perform differently
sw.ElapsedTicks

##Sha256 hash of the above information combined
###Combine all of the information above and hash it to a fixed length string
var hash=ComputeSha256Hash(proccessId+machineName+randomNumber+sw.ElapsedTicks);

##Toast the prepared hash between two newly generated Guid/UUID, remove the dashes and convert to UpperInvariant
var hash=ComputeSha256Hash(proccessId+machineName+randomNumber+sw.ElapsedTicks);

#Result is a HGuid, a highly improved unique string thats 128 characters long
##While it's basically stronger than double of a normal Guid, 
##Algorithm adds further machine, performance, time(with more resolution) specific information greatly reducing the collision chance.
var HGuidResult = $"{Guid.NewGuid()}{hash}{Guid.NewGuid().ToString()}".Replace("-", "");
