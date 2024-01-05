from templateframework.metadata import Metadata
import os
import glob
from itertools import takewhile
import yaml
import uuid
import json

def run(metadata: Metadata = None):
    all_inputs = metadata.all_inputs()
    inputs_local = metadata.inputs
    inputs_global = metadata.global_inputs
    inputs_envs = metadata.inputs_envs
    inputs_computed = metadata.computed_inputs
    inputs_global_computed = metadata.global_computed_inputs

    migrationWildCard = os.getcwd() + "\\src\\"+all_inputs["solution_name"]+".Infrastructure\\Migrations\\*"+all_inputs["entity_name"]+".cs"
    migrationList = glob.glob(migrationWildCard)[0].split("\\")
    migrationName = migrationList[len(migrationList) - 1]
    print(migrationName)
    metadata.inputs_envs['migration_name'] = migrationName

    # api_id = str(uuid.uuid4())
    # login_id = str(uuid.uuid4())
    # obj = { 'api_name': all_inputs['api_name'], 'api_id': api_id, 'login_id': login_id, 'inputs_local': inputs_local}
    # hasApis = False
    # for _input in metadata.global_computed_inputs:
    #     if (_input == 'apis'):
    #         hasApis = True

    # if (not hasApis):
    #     metadata.global_computed_inputs['apis'] = [obj]
    # else:
    #     metadata.global_computed_inputs['apis'].append(obj)
        
    # metadata.inputs_envs['api_id'] = api_id
    # metadata.inputs_envs['login_id'] = login_id
    # metadata.inputs_envs['apis_len'] = len(metadata.global_computed_inputs['apis'])
    return metadata