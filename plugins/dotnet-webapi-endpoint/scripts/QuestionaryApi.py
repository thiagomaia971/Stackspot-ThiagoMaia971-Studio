from templateframework.metadata import Metadata
from itertools import takewhile
import yaml
import uuid
import questionary

def run(metadata: Metadata = None):
    all_inputs = metadata.all_inputs()
    inputs_local = metadata.inputs
    inputs_global = metadata.global_inputs
    inputs_envs = metadata.inputs_envs
    inputs_computed = metadata.computed_inputs
    inputs_global_computed = metadata.global_computed_inputs

    def selectApiName(n):
        return n['api_name']
    apiNames = list(map(selectApiName, metadata.global_computed_inputs['apis']))
    api_to_create_endpoint = questionary.select("Witch Api Project", apiNames).ask()

    for api in metadata.global_computed_inputs['apis']:
        if api["api_name"] == api_to_create_endpoint:
            metadata.inputs_envs['api_name'] = api_to_create_endpoint
            metadata.inputs_envs['api_id'] = api["api_id"]
            metadata.inputs_envs['login_id'] = api["login_id"]

    return metadata