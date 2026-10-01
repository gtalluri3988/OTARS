
  INSERT INTO Menu (Caption, Description, Url, ParentId,id,IsActive)
  VALUES (
    'Agents Movement Report',
    'Agents Movement Report',
    '~/Report/AgentsMovementReport',
    @ReportsParentMenuId,
   @id,
   1
  );

