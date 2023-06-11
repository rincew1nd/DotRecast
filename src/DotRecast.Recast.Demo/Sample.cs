/*
Copyright (c) 2009-2010 Mikko Mononen memon@inside.org
recast4j copyright (c) 2015-2019 Piotr Piastucki piotr@jtilia.org
DotRecast Copyright (c) 2023 Choi Ikpil ikpil@naver.com

This software is provided 'as-is', without any express or implied
warranty.  In no event will the authors be held liable for any damages
arising from the use of this software.
Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:
1. The origin of this software must not be misrepresented; you must not
 claim that you wrote the original software. If you use this software
 in a product, an acknowledgment in the product documentation would be
 appreciated but is not required.
2. Altered source versions must be plainly marked as such, and must not be
 misrepresented as being the original software.
3. This notice may not be removed or altered from any source distribution.
*/

using System.Collections.Generic;
using DotRecast.Detour;
using DotRecast.Recast.Demo.Draw;
using DotRecast.Recast.DemoTool.Geom;

using DotRecast.Recast.Demo.UI;
using DotRecast.Recast.DemoTool;

namespace DotRecast.Recast.Demo;

public class Sample
{
    private DemoInputGeomProvider _inputGeom;
    private DtNavMesh _navMesh;
    private DtNavMeshQuery _navMeshQuery;
    private readonly RcSettings _settings;
    private IList<RecastBuilderResult> _recastResults;
    private bool _changed;

    public Sample(DemoInputGeomProvider inputGeom, IList<RecastBuilderResult> recastResults, DtNavMesh navMesh,
        RcSettingsView settingsView, RecastDebugDraw debugDraw)
    {
        _inputGeom = inputGeom;
        _recastResults = recastResults;
        _navMesh = navMesh;
        _settings = settingsView.GetSettings();
        SetQuery(navMesh);
        _changed = true;
    }

    private void SetQuery(DtNavMesh navMesh)
    {
        _navMeshQuery = navMesh != null ? new DtNavMeshQuery(navMesh) : null;
    }

    public DemoInputGeomProvider GetInputGeom()
    {
        return _inputGeom;
    }

    public IList<RecastBuilderResult> GetRecastResults()
    {
        return _recastResults;
    }

    public DtNavMesh GetNavMesh()
    {
        return _navMesh;
    }

    public RcSettings GetSettings()
    {
        return _settings;
    }

    public DtNavMeshQuery GetNavMeshQuery()
    {
        return _navMeshQuery;
    }

    public bool IsChanged()
    {
        return _changed;
    }

    public void SetChanged(bool changed)
    {
        _changed = changed;
    }

    public void Update(DemoInputGeomProvider geom, IList<RecastBuilderResult> recastResults, DtNavMesh navMesh)
    {
        _inputGeom = geom;
        _recastResults = recastResults;
        _navMesh = navMesh;
        SetQuery(navMesh);
        _changed = true;
    }
}