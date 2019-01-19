from django.contrib import admin

from .models import Idea

@admin.register(Idea)
class IdeaAdmin(admin.ModelAdmin):
    list_display = ('id', 'name', 'projected_revenue', 'created', 'modified',)
    list_display_links = ('name',)
