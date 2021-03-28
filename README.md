
# Installing the Helm Chart

You can install this sample solution using Helm using this command:
```
helm upgrade --install napichart . --namespace=customer42 --create-namespace --set global.customer=customer42.batman.local
 ```

 If you don't yet have Helm installed, see https://helm.sh/docs/intro/install/


## DNS 
In the Helm install command above, the example shows a global customer value of 'customer42.batman.local'.
This example uses this value as the ingress host name... meaning the user has to request http://customer42.batman.local in order the see the application.

You have to create a DNS entry that maps customer42.batman.local to the IP address of your kubernetes cluster's ingress.
You could even make a wildcard DNS entry, mapping *.batman.local to your cluster's ingress address.

The easiest way to tell your computer to go to your local computer to associate this DNS name with the IP Address by making an entry of `192.168.199.108 customer42.batman.local` in your HOSTS file (found in c:\windows\system32\drivers\etc\ ) (where '192.168.199.108' is your local IP address used by your local kubernetes cluster.
