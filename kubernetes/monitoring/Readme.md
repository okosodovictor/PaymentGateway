To Deploy Monitoring use

```bash
# Add Helm Repo
helm repo add stable https://kubernetes-charts.storage.googleapis.com

# Update Helm Repo
helm repo update


# Deploy Helm Chart for Prometheus
helm install monitoring stable/prometheus-operator -f ./kubernetes/monitoring/prom-values.yaml --namespace monitoring
```