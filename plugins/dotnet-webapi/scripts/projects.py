from templateframework.metadata import Metadata
from itertools import takewhile
import yaml
import uuid

def run(metadata: Metadata = None):
    all_inputs = metadata.all_inputs()
    inputs_local = metadata.inputs
    inputs_global = metadata.global_inputs
    inputs_envs = metadata.inputs_envs
    inputs_computed = metadata.computed_inputs
    inputs_global_computed = metadata.global_computed_inputs

    apis = [all_inputs['api_name']]
    for plugin in metadata.history.spec.plugins:
        for x in plugin.inputs:
            if (x == "api_name"):
                apis.append(plugin.inputs[x])
    metadata.inputs_envs['apis'] = apis
    metadata.inputs_envs['api_id'] = uuid.uuid4()
    return metadata