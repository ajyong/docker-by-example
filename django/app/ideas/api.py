from rest_framework import routers, serializers, viewsets

from .models import Idea

class IdeaSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Idea
        fields = ('url', 'id', 'created', 'modified', 'name', 'description', 'projected_revenue')

class IdeaViewSet(viewsets.ModelViewSet):
    queryset = Idea.objects.all()
    serializer_class = IdeaSerializer
